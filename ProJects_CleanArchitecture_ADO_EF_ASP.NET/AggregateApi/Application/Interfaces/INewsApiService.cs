using Domain.NewsApi_ModelClasses;

namespace Application.Interfaces
{
    public interface INewsApiService
    {
        Task<NewsApiResponse> GetNewsDataAsync(string keyword);
    }
}
