
﻿using Domain.Entities;

namespace Library_Infrastructure.Interfaces
{
    public interface IBooksRepository
    {
        Books GetBookById(int id);
        Books GetBookByTitle(string title);
        IEnumerable<Books> GetAllBooks();
        IEnumerable<Books> GetAvailableBooks();
        void InsertBook(Books book);
        void BulkInsertBooks(Books books);
        void DeleteBookById(int id);
        void UpdateBookById(int id);
        void SoftDeleteBookById(int id);
        void HardDeleteBookById(int id);


}
