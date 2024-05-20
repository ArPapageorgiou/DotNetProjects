using Application.Interfaces;
using Infrastructure.Data;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddAvailableCopies(int bookId)
        {
            var book = _appDbContext.books.FirstOrDefault(x => x.BookId == bookId);
            if (book != null)
            {
                book.AvailableCopies += 1;
                _appDbContext.SaveChanges();    
            }
            else 
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public void AddRemoveBookCopy(int bookId, int copyChange)
        {
            var book = _appDbContext.books.FirstOrDefault(x => x.BookId == bookId);
            if (book != null) 
            { 
                //book.TotalCopies += copyChange;
                book.AvailableCopies += copyChange;
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public bool IsBookAvailable(int bookId)
        {
            return _appDbContext.books.Any(x => x.BookId == bookId);
        }

        public void RemoveAvailableCopies(int bookId)
        {
            var book = _appDbContext.books.FirstOrDefault(x => x.BookId == bookId);
            if (book != null)
            {
                book.AvailableCopies -= 1;
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Book does not exist");
            }
        }
    }
}
