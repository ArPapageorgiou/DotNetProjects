
﻿using Application.Interfaces;
using Domain.Models;


namespace Application
{
    public class Application : IApplication
    {
        private readonly IbookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly ITransactionRepository _transactionRepository;

        public Application(IbookRepository ibookRepository, IMemberRepository memberRepository, ITransactionRepository transactionRepository)
        {
            _bookRepository = ibookRepository;
            _memberRepository = memberRepository;
            _transactionRepository = transactionRepository;
        }

        public void AddRemoveBookCopy(int bookId, int ChangeByNumber)
        {
            try
            {
                if (_bookRepository.DoesItemExist(bookId)) 
                {
                    throw new ArgumentException("Book does not exist");
                }

                _bookRepository.AddRemoveBookCopy(bookId, ChangeByNumber);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void DeleteBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public Member GetMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public Transaction GetRentalTransaction(Transaction rentalTransaction)
        {
            throw new NotImplementedException();
        }

        public void InsertNewBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void InsertNewMember(Member member)
        {
            throw new NotImplementedException();
        }

        public void RentBook(int bookId, int memberId)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(int bookId, int memberId)
        {
            throw new NotImplementedException();
        }

    }
}
