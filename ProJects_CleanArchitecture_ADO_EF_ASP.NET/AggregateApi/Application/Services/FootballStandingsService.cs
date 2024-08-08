using Application.Interfaces;
using Domain.FootballAPI_ModelClasses.ApiFootball;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Application.AppConstants;
using Domain.FootballAPI_ModelClasses;
using Microsoft.Extensions.Logging;


namespace Application.Services
{
    public class FootballStandingsService : IFootballStandingsService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IFootballAPI_HttpClient _footballStandingshttpClient;
        private readonly ILogger<FootballStandingsService> _logger;

        public FootballStandingsService(IFootballAPI_HttpClient footballStandingshttpClient, IDistributedCache distributedCache, ILogger<FootballStandingsService> logger)
        {
            _footballStandingshttpClient = footballStandingshttpClient;
            _distributedCache = distributedCache;
            _logger = logger;
        }


        public async Task<ApiResponse> GetFootbalStandingsAsync()
        {
            string leagueId = FootballLeagueId.SuperLeague1;
            string season = DateTime.Now.Year.ToString();


            var cacheKey = GetCacheKey(leagueId, season);
            _logger.LogInformation($"Fetching data from cache with key: {cacheKey}");

            var footballStandingResponse = await _distributedCache.GetRecordAsync<ApiResponse>(cacheKey, GetJsonSerializerOptions());

            if (footballStandingResponse == null)
            {
                _logger.LogInformation("Data not found in cache. Fetching from API.");

                footballStandingResponse = await FetchFootballStandingFromApi(leagueId, season);

                if (footballStandingResponse == null)
                {

                    _logger.LogInformation("API response is null. Creating default response.");

                    footballStandingResponse = await CreateDefaultFootballStandingResponse();
                }
                else
                {

                    _logger.LogInformation("Data fetched from API. Setting data in cache.");
                    await _distributedCache.SetRecordAsync(GetCacheKey(leagueId, season), footballStandingResponse);
                }
            }
            else
            {
                _logger.LogInformation("Data fetched from cache.");

            }

            return footballStandingResponse;
        }

        private static string GetCacheKey(string leagueId, string season)
        {
            var keyParts = new List<string>();

            if (leagueId != null)
            {
                keyParts.Add($"league_{leagueId}");

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


        private async Task<ApiResponse> FetchFootballStandingFromApi(string leagueId, string season)
        {
            try
            {
                var footballStandingData = await _footballStandingshttpClient.GetFootballDataAsync(leagueId, season);

                return footballStandingData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching data from API: {ex.Message}");
                return null;
            }

        }

        private async Task<ApiResponse> CreateDefaultFootballStandingResponse()
        {
            var defaultResponse = new ApiResponse
            {
                Get = "N/A",
                Parameters = new Parameters
                {
                    League = "N/A",
                    Season = "N/A"
                },

                Errors = new string[10],

                Results = -1,
                Paging = new Paging
                {
                    Current = -1,
                    Total = -1
                },
                Response = new List<Response>
                {
                    new Response
                    {
                        League = new League
                        {
                            Id = -1,
                            Name = "N/A",
                            Country = "N/A",
                            Logo = "N/A",
                            Flag = "N/A",
                            Season = -1,
                            Standings = new List<List<Standing>>
                            {
                                new List<Standing>
                                {
                                    new Standing
                                    {
                                        Rank = -1,
                                        Team = new Team
                                        {
                                            Id = -1,
                                            Name = "N/A",
                                            Logo = "N/A"
                                        },
                                        Points = -1,
                                        GoalsDiff = -1,
                                        Group = "N/A",
                                        Form = "N/A",
                                        Status = "N/A",
                                        Description = "N/A",
                                        All = new All
                                        {
                                            Played = -1,
                                            Win = -1,
                                            Draw = -1,
                                            Lose = -1,
                                            Goals = new Goals
                                            {
                                                For = -1,
                                                Against = -1
                                            }
                                        },
                                        Home = new Home
                                        {
                                            Played = -1,
                                            Win = -1,
                                            Draw = -1,
                                            Lose = -1,
                                            Goals = new Goals
                                            {
                                                For = -1,
                                                Against = -1
                                            }
                                        },
                                        Away = new Away
                                        {
                                            Played = -1,
                                            Win = -1,
                                            Draw = -1,
                                            Lose = -1,
                                            Goals = new Goals
                                            {
                                                For = -1,
                                                Against = -1
                                            }
                                        },
                                        Update = DateTime.MinValue
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return defaultResponse;

        }




    }
}
