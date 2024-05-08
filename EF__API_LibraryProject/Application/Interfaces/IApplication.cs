
﻿using Domain.Models;



namespace Application.Interfaces
{
    public interface IApplication
    {

        void GetBook(int bookId);
        void GetAllBooks();
        void InsertNewBook(Book book);
        void AddRemoveBookCopy(int bookId, int ChangeByNumber);
        void RentBook(int bookId, int memberId);
        void ReturnBook(int bookId, int memberId);
        void DeleteBook(int bookId);
        void GetMember(int memberId);
        void DeleteMember(int memberId);


    }
}
