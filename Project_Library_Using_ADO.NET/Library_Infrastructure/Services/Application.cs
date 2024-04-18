using Domain.Entities;
using Library_Application.Interfaces;

namespace Library_Application.Services
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
                        int numberOfAvailablecopies = _booksRepository.GetBook(bookId).AvailableCopies;
                        Console.WriteLine($"Book with id number {bookId} has {numberOfAvailablecopies} available.");
                        return _booksRepository.GetBook(bookId);
                    }
                    else
                    {
                        Console.WriteLine("Book has no available copies.");
                        return _booksRepository.GetBook(bookId);
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

        
        
        public void AddRemoveBookCopy(int bookId, int changeByNumber) 
        {
            try
            {
                if (_booksRepository.DoesBookExist(bookId))
                {
                    _booksRepository.AddRemoveBookCopy(bookId, changeByNumber);
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        
        public void CreateNewBook(Books book) 
        {
            try
            {
                _booksRepository.InsertNewBook(book);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        
        
        public Members SearchMember(int memberId) 
        {
            try
            {
                if (_membersRepository.DoesMemberExist(memberId))
                {
                    return _membersRepository.GetMember(memberId);
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
        
        
        
        public void RentBookToMember(int memberId,int bookId) 
        {
            try
            {
                if (_membersRepository.DoesMemberExist(memberId) && _booksRepository.DoesBookExist(bookId))
                {
                    if (_membersRepository.MemberHasMaxBooks(memberId))
                    {
                        Console.WriteLine("Member has reached the rental limit.");
                    }
                    else if (_transactionsRepository.HasMemberAlreadyRentedBook(memberId, bookId)) 
                    {
                        Console.WriteLine($"Member allready owes one book with id number {bookId}");
                    }
                    else
                    {
                        _transactionsRepository.CreateTransaction(memberId, bookId);
                        _membersRepository.AddRentedBookToMember(memberId);
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
                    
                    if (_transactionsRepository.DoesTransactionExist(memberId, bookId))
                    {
                        _transactionsRepository.UpdateTransaction(memberId, bookId);
                        _membersRepository.RemoveRentedBookFromMember(memberId);
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
            try
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
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        

    }
}
