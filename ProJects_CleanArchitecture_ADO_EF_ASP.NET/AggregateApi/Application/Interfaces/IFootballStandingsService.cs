using Domain.FootballAPI_ModelClasses;
using Domain.FootballAPI_ModelClasses.ApiFootball;

namespace Application.Interfaces
{
    internal interface IFootballStandingsService
    {
        Task<IEnumerable<ApiResponse>> GetFootbalStandings(string league, string season);
    }
}
