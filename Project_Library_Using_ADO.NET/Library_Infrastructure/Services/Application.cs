using Domain.Entities;
using Library_Infrastructure.Interfaces;
using System.Net;

namespace Library_Infrastructure.Services
{
    public class Application : IApplication
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMembersRepository _membersRepository;
        private  ITransactionsRepository _transactionsRepository;

        public Application(IBooksRepository booksRepository,
            IMembersRepository membersRepository,
            ITransactionsRepository transactionsRepository)
        {
            _booksRepository = booksRepository;
            _membersRepository = membersRepository;
            _transactionsRepository = transactionsRepository;
        }

        public Books SearchBook(int bookId) 
        {
            try
            {
                if (_booksRepository.DoesBookExist(bookId))
                {
                    if (_booksRepository.IsBookAvailable(bookId))
                    {
                        return _booksRepository.GetBook(bookId);
                    }
                    else
                    {
                        Console.WriteLine("Book is not available.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while searching for the book: {ex.Message}");
                return null;
            }
            
        }

        public Books SearchBook(string title) 
        {
            try
            {
                if (_booksRepository.DoesBookExist(title))
                {
                    if (_booksRepository.IsBookAvailable(title))
                    {
                        return _booksRepository.GetBook(title);
                    }
                    else
                    {
                        Console.WriteLine("Book is not available.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while searching for the book: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<Books> SearchAllRentedBooks()
        {
             try
            {
                return _booksRepository.GetAllRentedBooks();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<Books> SearchAllNotRentedBooks() 
        {
            try
            {
                return _booksRepository.GetAllNotRentedBooks();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search: {ex.Message}");
                return null;
            }
            
        }

        public IEnumerable<Books> SearchAllBooks() 
        {
            try
            {
                return _booksRepository.GetAllBooks();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<Books> SearchAllAvailableBooks() 
        {
            try
            {
                return _booksRepository.GetAvailableBooks();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search: {ex.Message}");
                return null;
            }
        }
        
        public void InsertBookCopy(int bookId, int increaseByNumber) 
        {
            if (_booksRepository.DoesBookExist(bookId)) 
            {
                _booksRepository.IncreaseBooks(bookId, increaseByNumber);
            }
            else
            {
                Console.WriteLine();
            }
        }

        public void CreateNewBook(Books book) 
        {
            _booksRepository.InsertNewBook(book);
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
        
        public Members SearchMember(int id) 
        {
            try
            {
                if (_membersRepository.DoesMemberExist(id))
                {
                    return _membersRepository.GetMember(id);
                }
                else
                {
                    Console.WriteLine("Member not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while searching for the member: {ex.Message}");
                return null;
            }
        }
        public Members SearchMember(string fullName)
        {
            try
            {
                if (_membersRepository.DoesMemberExist(fullName))
                {
                    return _membersRepository.GetMember(fullName);
                }
                else
                {
                    Console.WriteLine("Member not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while searching for the member: {ex.Message}");
                return null;
            }
        }

        public void CreateMember(Members member) 
        {
            try
            {
                _membersRepository.InsertMember(member);
                Console.WriteLine($"New member profile created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating new member profile: {ex.Message}");
            }
        }
        public void RentBookToMember(int memberId,int bookId,Transactions transaction) 
        {
            try
            {
                if (_membersRepository.DoesMemberExist(memberId) && _booksRepository.DoesBookExist(bookId))
                {
                    if (_membersRepository.MemberHasMaxBooks(memberId))
                    {
                        Console.WriteLine("Member has reached the rental limit.");
                    }
                    else
                    {
                        _transactionsRepository.CreateTransaction(memberId, bookId);
                    }
                }
                else 
                {
                    Console.WriteLine("Member and/or book not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while trying to rent the book with id number {bookId} to member with id number {memberId}: {ex.Message}");
            }
        }

        public void ReturnBook(int memberId, int bookId) 
        {
            try
            {
                if (_membersRepository.DoesMemberExist(memberId) && _booksRepository.DoesBookExist(bookId))
                {
                    var transaction = _transactionsRepository.GetTransaction(memberId, bookId);
                    if (transaction != null)
                    {
                        _transactionsRepository.UpdateTransaction(transaction);
                    }
                    else 
                    {
                        Console.WriteLine("Transaction not found.");
                    }
                }
                else 
                {
                    Console.WriteLine("Member and/or book not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while trying to return book with id number {bookId} from member with id number {memberId}: {ex.Message} ");
            }
        }

        public void HardDeleteMember(int memberId) 
        {
            if (_membersRepository.DoesMemberExist(memberId)) 
            {
                _membersRepository.DeleteMember(memberId);
                Console.WriteLine($"Member with id number {memberId} has been deleted.");
            }
            else 
            {
                Console.WriteLine("Member not found.");
            }
        }
        

    }
}
