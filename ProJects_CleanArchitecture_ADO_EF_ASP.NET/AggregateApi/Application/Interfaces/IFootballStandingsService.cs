using Domain.FootballAPI_ModelClasses;
using Domain.FootballAPI_ModelClasses.ApiFootball;

namespace Application.Interfaces
{

    public interface IFootballStandingsService
    {
        Task<ApiResponse> GetFootbalStandingsAsync(string league, string season);

    }
}
