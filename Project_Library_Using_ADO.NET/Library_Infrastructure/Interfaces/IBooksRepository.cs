
﻿using Domain.Entities;

namespace Library_Infrastructure.Interfaces
{
    public interface IBooksRepository
    {
        bool DoesBookExist(int bookId);//
        Books GetBookById(int id);//
        Books GetBookByTitle(string title);//
        IEnumerable<Books> GetAllBooks();//
        IEnumerable<Books> GetAvailableBooks();//
        IEnumerable<Books> GetAllRentedBooks();//
        IEnumerable<Books> GetAllNotRentedBooks();//
        void InsertNewBook(Books book);//
        void IncreaseBooks(int bookId, int increaseByNumber);//
        void ReduceBooks(int bookid, int reduceByNumber);//
        void BulkInsertBooks(Books books);
        void UpdateBookById(int id);
        void SoftDeleteBookById(int id);
        void HardDeleteBookById(int id);


}
