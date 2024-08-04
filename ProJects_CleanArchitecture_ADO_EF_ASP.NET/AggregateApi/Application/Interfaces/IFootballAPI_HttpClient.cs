using Domain.FootballAPI_ModelClasses.ApiFootball;

namespace Application.Interfaces
{
    public interface IFootballAPI_HttpClient
    {
        Task<ApiResponse> GetFootballDataAsync(string leagueId, string season);
    }
}
