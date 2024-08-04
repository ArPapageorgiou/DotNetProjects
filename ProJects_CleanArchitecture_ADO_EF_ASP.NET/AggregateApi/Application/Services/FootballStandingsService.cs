using Application.Interfaces;
using Domain.FootballAPI_ModelClasses.ApiFootball;
using Microsoft.Extensions.Caching.Distributed;

using System.Text.Json;
using Application.AppConstants;
using Domain.FootballAPI_ModelClasses;


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


        public async Task<ApiResponse> GetFootbalStandingsAsync(string leagueId, string season)
        {
            var footballStandingResponse = await _distributedCache.GetRecordAsync<ApiResponse>(GetCacheKey(leagueId, season), GetJsonSerializerOptions());

            if (footballStandingResponse == null)
            {
                footballStandingResponse = await FetchFootballStandingFromApi();
            }
            else
            {
                footballStandingResponse = await CreateDefaultFootballStandingResponse();
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

        private async Task<ApiResponse> FetchFootballStandingFromApi()
        {
            var league = FootballLeagueId.SuperLeague1;

            try
            {
                var footballStandingData = await _footballStandingshttpClient.GetFootballDataAsync(league, DateTime.Now.Year.ToString());
                return footballStandingData;
            }
            catch (Exception)
            {
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
                Errors = new List<string> { "N/A" },
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
