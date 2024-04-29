using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    internal interface IBookRepository
    {
        bool DoesBookExistById (int bookId);
        Book GetBookById (int bookId);
        IEnumerable<Book> GetAllBooks();
        bool IsBookAvailable (int bookId);
        void InsertNewBook (Book book);
        void AddRemoveBookCopy(int bookId, int increaseByNumber);
        void DeleteBook(int bookId);
    }
}
