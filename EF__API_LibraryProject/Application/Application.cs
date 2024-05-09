
﻿using Application.Interfaces;
using Domain.Models;
using System.Net;

namespace Application
{
    internal class Application : IApplication
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IRentalTransaction _rentalTransaction;

        public Application(IBookRepository bookRepository,IMemberRepository memberRepository, IRentalTransaction rentalTransaction)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _rentalTransaction = rentalTransaction;
        }

        public void AddRemoveBookCopy(int bookId, int ChangeByNumber)
        {
            if (_bookRepository.DoesBookExistById(bookId)) 
            {
                _bookRepository.AddRemoveBookCopy(bookId, ChangeByNumber);
            }
            else 
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public void DeleteBook(int bookId)
        {
            if (_bookRepository.DoesBookExistById(bookId))
            {
                _bookRepository.DeleteBook(bookId);
            }
            else
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public void DeleteMember(int memberId)
        {
            if (_memberRepository.DoesMemberExistById(memberId))
            {
                _memberRepository.DeleteMember(memberId);
            }
            else
            {
                throw new ArgumentException("Member does not exist");
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBook(int bookId)
        {
            if (_bookRepository.DoesBookExistById(bookId))
            {
                return _bookRepository.GetBookById(bookId);
            }
            else
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public Member GetMember(int memberId)
        {
            if (_memberRepository.DoesMemberExistById(memberId))
            {
                return _memberRepository.GetMemberById(memberId);
            }
            else
            {
                throw new ArgumentException("Member does not exist");
            }
        }

        public void InsertNewBook(Book book)
        {
            _bookRepository.InsertNewBook(book);
        }

        public void RentBook(int bookId, int memberId)
        {
           if (!_bookRepository.DoesBookExistById(bookId)) 
            {
                throw new ArgumentException("Book does not exist");
            }

            if (!_memberRepository.DoesMemberExistById(memberId)) 
            {
                throw new ArgumentException("Member does not exist");
            }

            if (!_bookRepository.IsBookAvailable(bookId)) 
            {
                throw new ArgumentException("Book is not available");
            }

            if (!_memberRepository.MemberHasMaxBooks(memberId)) 
            {
                throw new ArgumentException("Member has reached the rental limit of 2 books");
            }

            _rentalTransaction.CreateTransaction(bookId, memberId);

        }

        public void ReturnBook(int bookId, int memberId)
        {
            if (!_bookRepository.DoesBookExistById(bookId))
            {
                throw new ArgumentException("Book does not exist");
            }

            if (!_memberRepository.DoesMemberExistById(memberId))
            {
                throw new ArgumentException("Member does not exist");
            }

            if (_rentalTransaction.DoesTransactionExist(memberId, bookId)) 
            {
                throw new ArgumentException("Transaction does not exist");
            }

            _rentalTransaction.UpdateTransaction(memberId, bookId);
        }

    }
}