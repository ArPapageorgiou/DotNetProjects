
﻿using Domain.Entities;

namespace Library_Application.Interfaces
{
    public interface IBooksRepository
    {


        bool DoesBookExistById(int bookId);

        bool DoesBookExistByTitle(string title);
        bool IsBookAvailable(int bookId);
        bool IsBookAvailable(string title);
        Books GetBook(int bookId);
        Books GetBook(string title);
        IEnumerable<Books> GetAllBooks();
        IEnumerable<Books> GetAvailableBooks();
        IEnumerable<Books> GetAllRentedBooks();
        IEnumerable<Books> GetAllNotRentedBooks();
        void InsertNewBook(Books book);

        void AddRemoveBookCopy(int bookId, int increaseByNumber);
        

    }

}
