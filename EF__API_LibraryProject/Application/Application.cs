
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

        public void GetAllBooks()
        {
            _bookRepository.GetAllBooks();
        }

        public void GetBook(int bookId)
        {
            if (_bookRepository.DoesBookExistById(bookId))
            {
                _bookRepository.GetBookById(bookId);
            }
            else
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public void GetMember(int memberId)
        {
            if (_memberRepository.DoesMemberExistById(memberId))
            {
                _memberRepository.GetMemberById(memberId);
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
            if (_bookRepository.DoesBookExistById(bookId))
            {
                if (_bookRepository.IsBookAvailable(bookId) && !_memberRepository.MemberHasMaxBooks(memberId))
                {
                    _rentalTransaction.CreateTransaction(bookId, memberId);
                }
                else 
                {
                    throw new Exception("Book is not available or member has max Books");
                }
            }
            else
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public void ReturnBook(int bookId, int memberId)
        {
            if (_bookRepository.DoesBookExistById(bookId) && _memberRepository.DoesMemberExistById(memberId))
            {
                if (_rentalTransaction.DoesTransactionExist(memberId, bookId))
                {
                    _rentalTransaction.UpdateTransaction(memberId, bookId);
                }
                else 
                {
                    throw new ArgumentException("Transaction does not exist");
                }
            }
            else 
            { 
            throw new ArgumentException("Either Book or Member does not exist");
            }
        }

    }
}
