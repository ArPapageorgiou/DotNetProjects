using Application.Interfaces;
using Domain.WeatherBitApi_Models;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Wrap;
using Polly.CircuitBreaker;
using System.Text.Json;
using System.Diagnostics;
using Domain.ApiRequestStatistic;

namespace Infrastructure.Repositories
{
    public class WeatherHttpClient : IWeatherHttpClient
    {
        private readonly IRequestStatisticRepository _requestStatistic; 
        private HttpClient _httpClient;
        private readonly string BaseUrl;
        private readonly string ApiKey;
        private readonly AsyncPolicyWrap<HttpResponseMessage> _retryAndBreakerPolicy;
        public WeatherHttpClient(HttpClient httpClient, IConfiguration configuration, IRequestStatisticRepository apiRequestStatistic)
        {
            _httpClient = httpClient;
            BaseUrl = configuration["ApiSettings:WeatherBitUrl"];
            ApiKey = configuration["ApiSettings:WeatherBitApiKey"];

            //Define a retry policy where the http client will retry up to 3 times with an exponentialy
            //increasing timespan between retrt attempts.In Math.Pow(2, retryAttempt) 2 is the base while retryAttempt
            //is the power we raise 2 to.
            var retryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            //Define CircuitBreakerPolicy. Break circuit after three consecutive failures.
            var circuitBreakerPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));

            //Combine Retry asnd Circuit Breaker policies
            _retryAndBreakerPolicy = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy);

            _requestStatistic = apiRequestStatistic;

        }
        public async Task<WeatherData> GetWeatherAsync(string countryCode, string cityName)
        {
            var url = $"{BaseUrl}?&city={cityName}&country={countryCode}&key={ApiKey}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response;

            var stopWatch = Stopwatch.StartNew();

            try
            {
                //Send request with retry and circuit breaker policies
                response =  await _retryAndBreakerPolicy.ExecuteAsync(() => _httpClient.SendAsync(request));
            }
            catch (BrokenCircuitException)
            {

                throw new Exception("Circuit Breaker is open. Unable to fetch data from the Api");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while fetching data from the api");
            }
            finally 
            { 
                stopWatch.Stop();
                _requestStatistic.AddRequestStatistics(new RequestStatistic()
                {
                    ApiName = "WeatherBit",
                    ResponseTime = stopWatch.ElapsedMilliseconds,
                    Timestamp = DateTime.Now,
                });
            }

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var weatherApiResponse = JsonSerializer.Deserialize<WeatherData>(json, options);

                return weatherApiResponse;
            }
            else
            {
                throw new Exception($"unable to fetch weather from the Api. Status code: {response.StatusCode}");
            }
        }
    }
}
