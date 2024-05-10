using EF_API_LibraryProject.DTOs;
using Microsoft.AspNetCore.Mvc;
﻿using Domain.Models;



namespace Application.Interfaces
{
    public interface IApplication
    {

        Book GetBook(int bookId);
        IEnumerable<Book> GetAllBooks();
        int InsertNewBook([FromBody] BookRequest bookRequest);
        void AddRemoveBookCopy(int bookId, int ChangeByNumber);
        void RentBook(int bookId, int memberId);
        void ReturnBook(int bookId, int memberId);
        void DeleteBook(int bookId);
        Member GetMember(int memberId);
        RentalTransaction GetRentalTransaction(int transactionId);
        int InsertNewMember([FromBody] MemberRequest memberRequest);
        void DeleteMember(int memberId);


    }
}
