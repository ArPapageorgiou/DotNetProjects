﻿using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using System.Linq;

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
            else { throw new ArgumentException("Book not found")}
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
            var book = _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null) 
            {
                return true;
            }
            else return false;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var allBooks = _appDbContext.Books.ToList();
            return allBooks;
        }

        public Book GetBookById(int bookId)
        {
           return _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
        }

        public void InsertNewBook(Book book)
        {
            
        }

        public bool IsBookAvailable(int bookId)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
            return book.AvailableCopies > 0;   
        }
    }
}
