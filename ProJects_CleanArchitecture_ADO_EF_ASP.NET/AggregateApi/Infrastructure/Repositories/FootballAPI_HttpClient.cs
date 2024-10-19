using Application.Interfaces;
using Domain.FootballAPI_ModelClasses.ApiFootball;
using Polly;
using Polly.Wrap;
using System.Diagnostics;
using Domain.ApiRequestStatistic;
using Polly.CircuitBreaker;
using System.Text.Json;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Repositories
{
    public class FootballAPI_HttpClient : IFootballAPI_HttpClient
    {

        private readonly IRequestStatisticRepository _requestStatisticRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AsyncPolicyWrap<HttpResponseMessage> _retryAndBreakerPolicy;
        private readonly ILogger<FootballAPI_HttpClient> _logger;


        public FootballAPI_HttpClient(IRequestStatisticRepository requestStatisticRepository, IHttpClientFactory httpClientFactory, ILogger<FootballAPI_HttpClient> logger)
        {
            _requestStatisticRepository = requestStatisticRepository;
            _httpClientFactory = httpClientFactory;

            _logger = logger;
            
            var retryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));

            _retryAndBreakerPolicy = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy);
        }

        public async Task<ApiResponse> GetFootballDataAsync(string leagueId, string season)
        {
            var client = _httpClientFactory.CreateClient("FootballApi");

            var url = $"?league={leagueId}&season={season}";
            _logger.LogDebug($"Constructed url = {url}");

            HttpResponseMessage response;

            //var stopWatch = Stopwatch.StartNew();

            try
            {
                response = await _retryAndBreakerPolicy.ExecuteAsync(() =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, url);
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
            //finally
            //{
            //    stopWatch.Stop();
            //    _requestStatisticRepository.AddRequestStatistics(new RequestStatistic
            //    {
            //        ApiName = "FootBallAPI",
            //        ResponseTime = stopWatch.ElapsedMilliseconds,
            //        Timestamp = DateTime.Now

            //    });
            //}

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                _logger.LogDebug($"Raw JSON Response: {json}");

                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                try
                {
                    var footBallAPIResponse = JsonSerializer.Deserialize<ApiResponse>(json, options);
                    _logger.LogDebug($"Deserialized Response: {footBallAPIResponse}");

                    return footBallAPIResponse;
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
