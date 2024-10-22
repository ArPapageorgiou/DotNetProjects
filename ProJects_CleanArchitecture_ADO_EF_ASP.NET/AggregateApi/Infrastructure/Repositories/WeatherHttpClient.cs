using Application.Interfaces;
using Domain.WeatherBitApi_Models;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Wrap;
using Polly.CircuitBreaker;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class WeatherHttpClient : IWeatherHttpClient
    {
        private readonly IConfiguration _configuration;
        private readonly IRequestStatisticRepository _requestStatistic; 
        private IHttpClientFactory _httpClientFactory;
        private readonly AsyncPolicyWrap<HttpResponseMessage> _retryAndBreakerPolicy;
        private readonly ILogger<IWeatherHttpClient> _logger;

        private readonly string ApiKey;

        public WeatherHttpClient(IConfiguration configuration, IRequestStatisticRepository apiRequestStatistic, IHttpClientFactory httpClientFactory, ILogger<IWeatherHttpClient> logger)
        {
            _httpClientFactory = httpClientFactory;

            ApiKey = configuration["ApiSettings:WeatherBitApiKey"];
            
            _logger = logger;


            //Define a retry policy where the http client will retry up to 3 times with an exponentialy
            //increasing timespan between retry attempts.
            //In Math.Pow(2, retryAttempt) 2 is the base while retryAttempt is the power we raise 2 to.
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
            var client = _httpClientFactory.CreateClient("WeatherApi");

            var url = $"?city={cityName}&country={countryCode}&key={ApiKey}";
            _logger.LogDebug($"Constructed url = {client.BaseAddress}{url}");


            _logger.LogDebug($"Constructed url = {url}");


            HttpResponseMessage response;



            try
            {
                //Send request with retry and circuit breaker policies
                response =  await _retryAndBreakerPolicy.ExecuteAsync(() =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    _logger.LogDebug($"Sending request to URL: {client.BaseAddress}{url}");
                    return client.SendAsync(request);
                });
            }
            catch (BrokenCircuitException)
            {
                _logger.LogError("Circuit Breaker is open. Unable to fetch data from the Api");
                throw new Exception("Circuit Breaker is open. Unable to fetch data from the Api");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                throw new Exception("An error occured while fetching data from the api");
            }

            

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                _logger.LogDebug($"Raw JSON Response: {json}");

                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                try
                {
                    var weatherApiResponse = JsonSerializer.Deserialize<WeatherData>(json, options);
                    _logger.LogDebug($"Deserialized Response: {weatherApiResponse}");

                    return weatherApiResponse;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Deserialization Error: {ex.Message}");
                    _logger.LogError($"Raw JSON: {json}");
                    throw new Exception("Error deserializing the API response");
                }
               
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Unable to fetch data from the API. Status code: {response.StatusCode}, Content: {errorContent}");
                throw new Exception($"unable to fetch Data from the Api. Status code: {response.StatusCode}, Content: {errorContent}");
            }
        }
    }
}
