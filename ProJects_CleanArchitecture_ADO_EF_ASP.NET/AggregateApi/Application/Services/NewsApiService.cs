using Application.Interfaces;
using Domain.NewsApi_ModelClasses;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Application.Services
{
    public class NewsApiService : INewsApiService
    {

        private readonly INewsAPI_HttpClient _httpClient;
        private readonly ILogger<INewsApiService> _logger;
        private readonly IDistributedCache _distributedCache;

        public NewsApiService(INewsAPI_HttpClient httpClient, ILogger<INewsApiService> logger, IDistributedCache distributedCache)
        {
            _httpClient = httpClient;
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<NewsApiResponse> GetNewsDataAsync(string keyword)
        {
            var newsResponse = await _distributedCache.GetRecordAsync<NewsApiResponse>(keyword, GetJsonSerializerOptions());

            if(newsResponse == null)
            {
                _logger.LogInformation("Data not found in cache. Fetching from API.");
                newsResponse = await FetchDataFromApi(keyword);

                if (newsResponse == null)
                {
                    _logger.LogInformation("API response is null. Creating default response.");
                    newsResponse = CreateDefaultNewsApiResponse();
                }
                else
                {
                    _logger.LogInformation("Data fetched from API. Setting data in cache.");
                    await _distributedCache.SetRecordAsync(keyword, newsResponse);
                }

            }
            else
            {
                _logger.LogInformation("Data fetched from cache.");
            }

            return newsResponse;
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }

        private static NewsApiResponse CreateDefaultNewsApiResponse()
        {
            return new NewsApiResponse
            {
                Status = "error",
                TotalResults = 0,
                Articles = new List<Article>()
            };
        }

        private async Task<NewsApiResponse> FetchDataFromApi(string keyword)
        {
            var newsApiResponse = await _httpClient.GetNewsAsync(keyword);

            return newsApiResponse;
        }
    }
}
