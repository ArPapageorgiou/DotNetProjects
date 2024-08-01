using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
           _appDbContext = appDbContext;
        }

        public void AddRemoveBookCopy(int bookId, int copyChange)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                if (copyChange > 0)
                {
                    book.TotalCopies += copyChange;
                    book.AvailableCopies += copyChange;
                }
                else if (copyChange < 0)
                {
                    if (book.AvailableCopies >= copyChange)
                    {
                        book.TotalCopies += copyChange;
                        book.AvailableCopies += copyChange;
                    }
                    else
                    {
                        throw new ArgumentException("Not enough copies available to remove");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid copy change value");
                }

                _appDbContext.SaveChanges();

            }
            else { throw new ArgumentException("Book does not exist"); }
        }

        public void DeleteBook(int bookId)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                _appDbContext.Books.Remove(book);
                _appDbContext.SaveChanges();
            }
            else 
            { 
                throw new ArgumentException("Book does not exist"); 
            }
        }

        public bool DoesBookExistById(int bookId)
        {
            return _appDbContext.Books.Any(b => b.BookId == bookId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _appDbContext.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
           return _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
        }

        public void InsertNewBook(Book book)
        {
            _appDbContext.Books.Add(book);
            _appDbContext.SaveChanges();
        }

        public bool IsBookAvailable(int bookId)
        {
            return _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId).AvailableCopies > 0;
        }

        public void AddAvailableCopies(int bookId) 
        {
            _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId).AvailableCopies += 1;
            _appDbContext.SaveChanges();
        }

        public void RemoveAvailableCopies(int bookId)
        {
            _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId).AvailableCopies -= 1;
            _appDbContext.SaveChanges();
        }
    }
}
