using Domain.NewsApi_ModelClasses;

namespace Application.Interfaces
{
    public interface INewsAPI_HttpClient
    {
        Task<NewsApiResponse> GetNewsAsync(string keyword);
    }
}
