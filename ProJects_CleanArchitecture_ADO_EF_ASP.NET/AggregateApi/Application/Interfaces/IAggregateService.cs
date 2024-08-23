using Domain.AggregateModels;

namespace Application.Interfaces
{
    public interface IAggregateService
    {
        Task<AggregateModel> GetAggregateDataAsync(string temperature, bool ascending, string keyword);
    }
}
