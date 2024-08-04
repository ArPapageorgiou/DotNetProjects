using Application.Interfaces;
using Domain.FootballAPI_ModelClasses.ApiFootball;
using Microsoft.Extensions.Caching.Distributed;
using Domain.FootballAPI_ModelClasses;
using System.Text.Json;

namespace Application.Services
{
    public class FootballStandingsService : IFootballStandingsService
    {

        private readonly IDistributedCache _distributedCache;
        private readonly IFootballAPI_HttpClient _footballStandingshttpClient;

        public FootballStandingsService(IFootballAPI_HttpClient footballStandingshttpClient, IDistributedCache distributedCache)
        {
            _footballStandingshttpClient = footballStandingshttpClient;
            _distributedCache = distributedCache;
        }

        public async Task<IEnumerable<ApiResponse>> GetFootbalStandings(string league, string season)
        {
            throw new NotImplementedException();
        }

        private static string GetCacheKey(string league, string season)
        {
            var keyParts = new List<string>();

            if (league != null)
            {
                keyParts.Add($"league_{league}");
            }

            if (season != null)
            {
                keyParts.Add($"season_{season}");
            }

            if (keyParts.Count() < 2)
            {
                return "DefaultFootballStandingCacheKey";
            }

            string cacheKey = string.Join(",", keyParts);
            return cacheKey;

        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        }

    }
}
