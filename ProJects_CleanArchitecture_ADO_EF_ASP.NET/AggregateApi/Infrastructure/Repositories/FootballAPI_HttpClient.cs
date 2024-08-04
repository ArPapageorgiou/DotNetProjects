using Application.Interfaces;
using Domain.FootballAPI_ModelClasses.ApiFootball;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Wrap;
using System.Diagnostics;
using Domain.ApiRequestStatistic;
using Polly.CircuitBreaker;
using System.Text.Json;


namespace Infrastructure.Repositories
{
    public class FootballAPI_HttpClient : IFootballAPI_HttpClient
    {

        private readonly IRequestStatisticRepository _requestStatisticRepository;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly AsyncPolicyWrap<HttpResponseMessage> _retryAndBreakerPolicy;

        public FootballAPI_HttpClient(IRequestStatisticRepository requestStatisticRepository, HttpClient httpClient, IConfiguration configuration)
        {
            _requestStatisticRepository = requestStatisticRepository;
            
            _httpClient = httpClient;
            
            _baseUrl = configuration["ApiSettings:FootballAPIUrl"];
            _apiKey = configuration["ApiSettings:FootballAPIApiKey"];

            var retryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));

            _retryAndBreakerPolicy = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy);

        }

        public async Task<ApiResponse> GetFootballData(string leagueId, string season)
        {
            var url = $"{_baseUrl}?&league={leagueId}&season={season}&key={_apiKey}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response;

            var stopWatch = Stopwatch.StartNew();

            try
            {
                response = await _retryAndBreakerPolicy.ExecuteAsync(() => _httpClient.SendAsync(request));
            }
            catch (BrokenCircuitException)
            {

                throw new Exception("Circuit Breaker is open. Unable to fetch data from the Api");
            }
            catch (Exception)
            {
                throw new Exception("An error occured while fetching data from the api");
            }
            finally
            {
                stopWatch.Stop();
                _requestStatisticRepository.AddRequestStatistics(new RequestStatistic
                {
                    ApiName = "FootBallAPI",
                    ResponseTime = stopWatch.ElapsedMilliseconds,
                    Timestamp = DateTime.Now

                });
            }

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var footBallAPIResponse = JsonSerializer.Deserialize<ApiResponse>(json, options);

                return footBallAPIResponse;

            }
            else
            {
                throw new Exception($"unable to fetch Data from the Api. Status code: {response.StatusCode}");
            }
        }
    }
}
