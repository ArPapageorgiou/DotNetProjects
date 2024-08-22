using Domain.AggregateModels;

namespace Application.Interfaces
{
    internal interface IAggregateService
    {
        Task<AggregateModel> GetAggregateDataAsync(string temperature, bool ascending, string keyword);
    }
}
