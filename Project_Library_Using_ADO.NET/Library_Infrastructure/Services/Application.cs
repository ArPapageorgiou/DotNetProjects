using Domain.Entities;
using Library_Infrastructure.Interfaces;
using System.Net;

namespace Library_Infrastructure.Services
{
    public class Application : IApplication
    {
        private IBooksRepository _booksRepository;
        private IMembersRepository _membersRepository;
        private ITransactionsRepository _transactionsRepository;

        public Application(IBooksRepository booksRepository,
            IMembersRepository membersRepository,
            ITransactionsRepository transactionsRepository)
        {
            _booksRepository = booksRepository;
            _membersRepository = membersRepository;
            _transactionsRepository = transactionsRepository;
        }

        public Books SearchBookById(int bookId) 
        {
            return _booksRepository.GetBookById(bookId);
        }

        public Books SearchBookByTitle(string title) 
        {
            return _booksRepository.GetBookByTitle(title);
        }

        public IEnumerable<Books> SearchAllRentedBooks() 
        { 
            return _booksRepository.GetAllRentedBooks();
        }

        public IEnumerable<Books> SearchAllNotRentedBooks() 
        {
            return _booksRepository.GetAllNotRentedBooks();
        }

        public IEnumerable<Books> SearchAllBooks() 
        {
            return _booksRepository.GetAllBooks();
        }

        public IEnumerable<Books> SearchAllAvailableBooks() 
        {
            return _booksRepository.GetAvailableBooks();
        }
        public void InsertBook(Books book, int bookId, int increaseByNumber) 
        {
            if (_booksRepository.DoesBookExist(bookId)) 
            {
                _booksRepository.IncreaseBooks(bookId, increaseByNumber);
            }
            else
            {
                _booksRepository.InsertNewBook(book);
            }
        }

        public void ReduceBookCopies(int bookId, int reduceByNumber) 
        {
            if (_booksRepository.DoesBookExist(bookId))
            {
                _booksRepository.ReduceBooks(bookId, reduceByNumber);
            }
            else
            {
                Console.WriteLine();
            }
        }
        
        public Members SearchMemberById(int id) //maybe i can overload a single searchmembermethod with an object parameter that can accept int and string??
        {
            return _membersRepository.GetMember(id);
        }
        public Members SearchMemberByName(string fullName)
        {
            return _membersRepository.GetMember(fullName);
        }

        public void CreateMember(Members member) 
        {
            _membersRepository.InsertMember(member);
        }
        public void RentBookToMember(int memberId,int bookId,Transactions transaction) 
        {
            if (_membersRepository.DoesMemberExist(memberId) && _booksRepository.DoesBookExist(bookId)) 
            {
                if (_membersRepository.MemberHasMaxBooks(memberId))
                {
                    Console.WriteLine();
                }
                else
                {
                    _transactionsRepository.CreateTransaction(memberId, bookId);
                }
            }
        }

        public void ReturnBook(int memberId, int bookId) 
        {
            if (_membersRepository.DoesMemberExist(memberId) && _booksRepository.DoesBookExist(bookId)) 
            {
                var transaction = _transactionsRepository.GetTransaction(memberId, bookId);
                if (transaction != null) 
                {
                    _transactionsRepository.UpdateTransaction(transaction);
                }
            }
        }

        public void HardDeleteMember(int memberId) 
        {
            if (_membersRepository.DoesMemberExist(memberId)) 
            {
                _membersRepository.DeleteMember(memberId);
            }
        }
        

    }
}
