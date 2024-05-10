using Domain.Models;



namespace Application.Interfaces
{
    public interface IBookRepository
    {

        bool DoesBookExistById (int bookId);
        Book GetBookById (int bookId);
        IEnumerable<Book> GetAllBooks();
        bool IsBookAvailable (int bookId);
        void InsertNewBook (Book book);
        void AddRemoveBookCopy(int bookId, int increaseByNumber);
        void AddAvailableCopies(int bookId);
        void RemoveAvailableCopies(int bookId);
        void DeleteBook(int bookId);

    }
}
