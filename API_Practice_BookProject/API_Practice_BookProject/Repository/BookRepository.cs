using API_Practice_BookProject.Data;
using API_Practice_BookProject.DTO_s;
using API_Practice_BookProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice_BookProject.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public void AddBook([FromBody] BookRequest bookRequest)
        {
            Book book = new Book 
            { 
            Author = bookRequest.Author,
            Title = bookRequest.Title,
            Description = bookRequest.Description,
            };

            _bookDbContext.books.Add(book);
            _bookDbContext.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var bookToDelete = _bookDbContext.books.FirstOrDefault(x => x.BookId == id);

            if (bookToDelete != null) 
            {
                _bookDbContext.books.Remove(bookToDelete);
                _bookDbContext.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDbContext.books.ToList();
        }

        public Book GetBookByAuthor(string Author)
        {
            return _bookDbContext.books.FirstOrDefault(x => x.Author == Author);
        }

        public Book GetBookById(int id)
        {
            return _bookDbContext.books.FirstOrDefault(x => x.BookId == id);
        }

        public IEnumerable<Book> GetRentedBooks()
        {
            return _bookDbContext.books.Where(x => x.isRented == true).ToList();
        }

        public void UpdateBook(int id, [FromBody] BookRequest bookRequest)
        {
            var book = _bookDbContext.books.FirstOrDefault(x => x.BookId == id);

            if (book != null) 
            {
                book.Author = bookRequest.Author;
                book.Description = bookRequest.Description;
                book.Title = bookRequest.Title;

                _bookDbContext.SaveChanges();

            }
        }
    }
}
