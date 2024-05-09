
﻿using Domain.Models;



namespace Application.Interfaces
{
    public interface IApplication
    {

        Book GetBook(int bookId);
        IEnumerable<Book> GetAllBooks();
        void InsertNewBook(Book book);
        void AddRemoveBookCopy(int bookId, int ChangeByNumber);
        void RentBook(int bookId, int memberId);
        void ReturnBook(int bookId, int memberId);
        void DeleteBook(int bookId);
        Member GetMember(int memberId);
        void DeleteMember(int memberId);


    }
}