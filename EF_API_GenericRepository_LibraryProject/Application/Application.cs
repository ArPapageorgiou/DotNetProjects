

using Application.Interfaces;
using Domain.Models;



namespace Application
{
    public class Application : IApplication
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly ITransactionRepository _transactionRepository;
        

        public Application(IBookRepository ibookRepository, IMemberRepository memberRepository, ITransactionRepository transactionRepository)
        {
            _bookRepository = ibookRepository;
            _memberRepository = memberRepository;
            _transactionRepository = transactionRepository;
            
        }

        public void AddRemoveBookCopy(int bookId, int ChangeByNumber)
        {
            if (_bookRepository.DoesItemExist(bookId))
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
            if (_bookRepository.DoesItemExist(bookId))
            {
                _bookRepository.Delete(bookId);
            }
            else
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public void DeleteMember(int memberId)
        {
            if (_memberRepository.DoesItemExist(memberId))
            {
                _memberRepository.Delete(memberId);
            }
            else
            {
                throw new ArgumentException("Member does not exist");
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBook(int bookId)
        {
            if (_bookRepository.DoesItemExist(bookId))
            {
                return _bookRepository.GetById(bookId);
            }
            else
            {
                throw new ArgumentException("Book does not exist");
            }
        }

        public Member GetMember(int memberId)
        {
            if (_memberRepository.DoesItemExist(memberId))
            {
                return _memberRepository.GetById(memberId);
            }
            else
            {
                throw new ArgumentException("Member does not exist");
            }
        }

        public IEnumerable<Transaction> GetTransactions(int memberId, int bookId)
        {

            var transactions = _transactionRepository.GetTransactions(memberId, bookId);

            if (transactions.Count() > 0)

            {
                return transactions;
            }
            else
            {
                throw new ArgumentException("No transaction was found");
            }
        }

        public void InsertNewBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public void InsertNewMember(Member member)
        {
            _memberRepository.Add(member);
        }

        public void RentBook(int bookId, int memberId)
        {
            if (!_bookRepository.DoesItemExist(bookId))
            {
                throw new ArgumentException("Book does not exist");
            }

            if (!_memberRepository.DoesItemExist(memberId))
            {
                throw new ArgumentException("Member does not exist");
            }

            if (!_bookRepository.IsBookAvailable(bookId))
            {
                throw new ArgumentException("Book is not available");
            }

            if (_transactionRepository.HasMemberAlreadyRentedBook(memberId, bookId))
            {
                throw new ArgumentException("Member allready owes a book with this ID");
            }

            if (_memberRepository.MemberHasMaxBooks(memberId))
            {
                throw new ArgumentException("Member has reached rental limit");
            }


            _transactionRepository.CreateTransaction(memberId, bookId);
            _bookRepository.RemoveAvailableCopies(bookId);
            _memberRepository.AddRentedBookToMember(memberId);
        
        }

        public void ReturnBook(int bookId, int memberId)
        {
            if (!_bookRepository.DoesItemExist(bookId))
            {
                throw new ArgumentException("Book does not exist");
            }

            if (!_memberRepository.DoesItemExist(memberId))
            {
                throw new ArgumentException("Member does not exist");
            }

            if (!_transactionRepository.DoesOpenTransactionExist(memberId, bookId)) 
            {
                throw new ArgumentException("Transaction does not exist");
            }

            _transactionRepository.UpdateTransaction(memberId, bookId);
            _bookRepository.AddAvailableCopies(bookId);
            _memberRepository.RemoveRentedBookFromMember(memberId);
        

        }

    }
}
