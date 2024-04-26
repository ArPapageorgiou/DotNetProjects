using API_Practice_BookProject.DTO_s;
using API_Practice_BookProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice_BookProject.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByAuthor(string Author);
        IEnumerable<Book> GetRentedBooks();
        void UpdateBook(int bookId, [FromBody] BookRequest bookRequest);
        void AddBook([FromBody] BookRequest bookRequest);
        void DeleteBook(int id);
    }
}
