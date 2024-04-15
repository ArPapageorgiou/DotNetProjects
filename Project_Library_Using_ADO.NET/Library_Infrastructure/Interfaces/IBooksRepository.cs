
﻿using Domain.Entities;

namespace Library_Infrastructure.Interfaces
{
    public interface IBooksRepository
    {

        bool DoesBookExist(int bookId);
        bool DoesBookExist(string title);
        bool IsBookAvailable(int bookId);
        bool IsBookAvailable(string title);
        Books GetBook(int id);
        Books GetBook(string title);
        IEnumerable<Books> GetAllBooks();
        IEnumerable<Books> GetAvailableBooks();
        IEnumerable<Books> GetAllRentedBooks();
        IEnumerable<Books> GetAllNotRentedBooks();
        void InsertNewBook(Books book);
        void IncreaseBooks(int bookId, int increaseByNumber);
        void ReduceBooks(int bookid, int reduceByNumber);


    }

}
