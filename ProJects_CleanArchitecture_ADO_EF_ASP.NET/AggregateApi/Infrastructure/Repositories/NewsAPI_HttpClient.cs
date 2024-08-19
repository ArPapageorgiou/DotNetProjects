using Application.Interfaces;
using Domain.NewsApi_ModelClasses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.CircuitBreaker;
using Polly.Wrap;
using System.Diagnostics;
using Domain.ApiRequestStatistic;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class NewsAPI_HttpClient : INewsAPI_HttpClient
    {

        private readonly IConfiguration _configuration;
        private readonly IRequestStatisticRepository _requestStatistic;
        private IHttpClientFactory _httpClientFactory;
        private readonly AsyncPolicyWrap<HttpResponseMessage> _retryAndBreakerPolicy;
        private readonly ILogger<INewsAPI_HttpClient> _logger;
        private readonly string _apiKey;

        public NewsAPI_HttpClient(IConfiguration configuration, IRequestStatisticRepository requestStatistic, IHttpClientFactory httpClientFactory, ILogger<INewsAPI_HttpClient> logger) 
        {
            _configuration = configuration;
            _requestStatistic = requestStatistic;
            _httpClientFactory = httpClientFactory;
            _logger = logger;

            _apiKey = configuration["ApiSettings:NewsApiKey"];

            var retryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));

            var retryAndBreakerPolicy = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy);
        }

        public async Task<NewsApiResponse> GetNewsAsync(string keyword)
        {
            var client = _httpClientFactory.CreateClient("NewsApi");

            var url = $"?q={keyword}&apiKey={_apiKey}";
            _logger.LogDebug($"Constructed url = {url}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response;

            var stopWatch = Stopwatch.StartNew();

            try
            {
                response = await _retryAndBreakerPolicy.ExecuteAsync(() => client.SendAsync(request));
            }
            catch (BrokenCircuitException)
            {
                _logger.LogError("Circuit Breaker is open. Unable to fetch data from the Api");
                throw new Exception("Circuit Breaker is open. Unable to fetch data from the Api");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                throw new Exception("An error occured while fetching data from the api");
            }
            finally
            {
                stopWatch.Stop();
                _requestStatistic.AddRequestStatistics(new RequestStatistic()
                {
                    ApiName = "NewsApi",
                    ResponseTime = stopWatch.ElapsedMilliseconds,
                    Timestamp = DateTime.Now,
                });
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
                    var newsApiResponse = JsonSerializer.Deserialize<NewsApiResponse>(json, options);
                    _logger.LogDebug($"Deserialized Response: {newsApiResponse}");

                    return newsApiResponse;
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
            throw new NotImplementedException();
        }
    }
}
