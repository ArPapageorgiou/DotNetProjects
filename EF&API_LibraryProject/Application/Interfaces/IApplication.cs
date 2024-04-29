
﻿using Domain.Models;



namespace Application.Interfaces
{
    internal interface IApplication
    {

        void GetBook(int bookId);
        void GetAllBooks(int bookId);
        void InsertNewBook(Book book);
        void AddRemoveBookCopy(int bookId, int ChangeByNumber);
        void RentBook(int bookId);
        void ReturnBook(int bookId);
        void DeleteBook(int bookId);
        void GetMember(int memberId);
        void DeleteMember(int memberId);


    }
}
