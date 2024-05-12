using Domain.Entities;
using Library_Application.Interfaces;

using System.Net;

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


        public void SearchBook(int bookId) 
        {
            try
            {
                Console.Clear();


                if (_booksRepository.DoesBookExistById(bookId))

                {
                    Books book = _booksRepository.GetBook(bookId);

                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Book ID: {book.BookId}");
                    Console.WriteLine($"Genre: {book.Genre}");
                    Console.WriteLine($"Description: {book.Description}");
                    Console.WriteLine($"ISBN: {book.ISBN}");
                    Console.WriteLine($"Total Copies: {book.TotalCopies}");
                    Console.WriteLine($"This title has {book.AvailableCopies} copies available.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Title with book ID {bookId} does not exist. Please check the information you provided and try again.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred during the search: {ex.Message}");
            }
            
        }

        
        

        public void SearchBook(string title) 

        {
            try
            {
                Console.Clear();

                if (_booksRepository.DoesBookExistByTitle(title))
                {
                    Books book = _booksRepository.GetBook(title);

                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Book ID: {book.BookId}");
                    Console.WriteLine($"Genre: {book.Genre}");
                    Console.WriteLine($"Description: {book.Description}");
                    Console.WriteLine($"ISBN: {book.ISBN}");
                    Console.WriteLine($"Total Copies: {book.TotalCopies}");
                    Console.WriteLine($"This title has {book.AvailableCopies} copies available.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Title with the title \"{title}\" does not exist. Please check the information you provided and try again.");
                }
            }
            catch (Exception ex)
            {
                    Console.WriteLine($"An error occurred during the search: {ex.Message}");
            }
        }

        
        

        public void SearchAllRentedBooks()

        {
             try
            {
                Console.Clear();
                
                List<Books> books = _booksRepository.GetAllRentedBooks().ToList();
                if (books.Count > 0)
                {
                    foreach (var item in books)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Title: {item.Title}");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Book ID: {item.BookId}");
                        Console.WriteLine($"Genre: {item.Genre}");
                        Console.WriteLine($"Description: {item.Description}");
                        Console.WriteLine($"ISBN: {item.ISBN}");
                        Console.WriteLine($"Total Copies: {item.TotalCopies}");
                        Console.WriteLine($"This title has {item.AvailableCopies} copies available.");
                    }
                }
                else 
                { 
                    Console.WriteLine("The list is empty");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter key to return to main menu");
                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search: {ex.Message}");
                
            }

        }

        
        

        public void SearchAllNotRentedBooks() 

        {

            try
            {
                Console.Clear();
                
                List<Books> books = _booksRepository.GetAllNotRentedBooks().ToList();
                if (books.Count > 0)
                {
                    foreach (var item in books)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Title: {item.Title}");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Book ID: {item.BookId}");
                        Console.WriteLine($"Genre: {item.Genre}");
                        Console.WriteLine($"Description: {item.Description}");
                        Console.WriteLine($"ISBN: {item.ISBN}");
                        Console.WriteLine($"Total Copies: {item.TotalCopies}");
                        Console.WriteLine($"This title has {item.AvailableCopies} copies available.");
                        
                    }
                }
                else { Console.WriteLine("The list is empty"); }

                Console.WriteLine();
                Console.WriteLine("Press Enter key to return to main menu");
                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search: {ex.Message}");

            }


        }

       
        

        public void SearchAllBooks() 

        {
            try
            {
                Console.Clear();
               
                List<Books> books = _booksRepository.GetAllBooks().ToList();
                if (books.Count > 0)
                {
                    foreach (var item in books)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Title: {item.Title}");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Book ID: {item.BookId}");
                        Console.WriteLine($"Genre: {item.Genre}");
                        Console.WriteLine($"Description: {item.Description}");
                        Console.WriteLine($"ISBN: {item.ISBN}");
                        Console.WriteLine($"Total Copies: {item.TotalCopies}");
                        Console.WriteLine($"This title has {item.AvailableCopies} copies available.");
                        
                    }
                }
                else { Console.WriteLine("The list is empty"); }

                Console.WriteLine();
                Console.WriteLine("Press Enter key to return to main menu");
                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search: {ex.Message}");

            }
        }

        
        

        public void SearchAllAvailableBooks() 

        {
            try
            {
                Console.Clear();
                
                List<Books> books = _booksRepository.GetAvailableBooks().ToList();  
                if (books.Count > 0)
                {
                    foreach (var item in books)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Title: {item.Title}");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Book ID: {item.BookId}");
                        Console.WriteLine($"Genre: {item.Genre}");
                        Console.WriteLine($"Description: {item.Description}");
                        Console.WriteLine($"ISBN: {item.ISBN}");
                        Console.WriteLine($"Total Copies: {item.TotalCopies}");
                        Console.WriteLine($"This title has {item.AvailableCopies} copies available.");
                    }
                }
                else { Console.WriteLine("The list is empty"); }

                Console.WriteLine();
                Console.WriteLine("Press Enter key to return to main menu");
                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search: {ex.Message}");

            }
        }


        
        

        public void AddRemoveBookCopy(int bookId, int changeByNumber) 

        {
            try
            {
                Console.Clear();


                if (_booksRepository.DoesBookExistById(bookId))

                {
                    _booksRepository.AddRemoveBookCopy(bookId, changeByNumber);

                    Console.WriteLine($"Title record with ID {bookId} has been updated");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Title with the title \"{bookId}\" does not exist. Please check the information you provided and try again.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();

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
                Console.Clear();

                _booksRepository.InsertNewBook(book);
                Console.WriteLine($"New book profile with Title \"{book.Title}\" has been created successfuly");

                Console.WriteLine();
                Console.WriteLine("Press Enter key to return to main menu");
                Console.ReadLine();

            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        

        

        public void SearchMember(int memberId) 

        {
            try
            {
                Console.Clear();


                if (_membersRepository.DoesMemberExistById(memberId))

                {

                    Members member = _membersRepository.GetMember(memberId);
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Full Name: {member.FirstName} {member.LastName}");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Member ID: {member.MemberId}");
                    Console.WriteLine($"Address: {member.Address}");
                    Console.WriteLine($"Phone: {member.Phone}");
                    Console.WriteLine($"E-mail: {member.Email}");
                    Console.WriteLine($"Owed items: {member.RentedBooksCount}");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine($"Member with ID \"{memberId}\" does not exist. Please check the information you provided and try again.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching for the member: {ex.Message}");
            }
        }
        
        
        

        public void SearchMember(string fullName)

        {
            try
            {
                Console.Clear();

                if (_membersRepository.DoesMemberExistByFullName(fullName))
                {
                    Members member = _membersRepository.GetMember(fullName);
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Full Name: {member.FirstName} {member.LastName}");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Member ID: {member.MemberId}");
                    Console.WriteLine($"Address: {member.Address}");
                    Console.WriteLine($"Phone: {member.Phone}");
                    Console.WriteLine($"E-mail: {member.Email}");
                    Console.WriteLine($"Owed items: {member.RentedBooksCount}");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Member with Name \"{fullName}\" does not exist. Please check the information you provided and try again.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching for the member: {ex.Message}");
            }

        }

        
        
        public void CreateMember(Members member) 
        {

            try
            {
                Console.Clear();

                _membersRepository.InsertMember(member);
                Console.WriteLine($"New member profile created.");
                Console.WriteLine();
                Console.WriteLine("Press Enter key to return to main menu");
                Console.ReadLine();
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
                Console.Clear();


                if (_membersRepository.DoesMemberExistById(memberId) && _booksRepository.DoesBookExistById(bookId))

                {
                    if (_booksRepository.IsBookAvailable(bookId)) 
                    {
                        Console.WriteLine("Book is not currently available.");
                        Console.WriteLine();
                        Console.WriteLine("Press Enter key to return to main menu");
                        Console.ReadLine();
                    }
                    else if (_membersRepository.MemberHasMaxBooks(memberId))
                    {
                        Console.WriteLine("Member has reached the rental limit.");
                        Console.WriteLine();
                        Console.WriteLine("Press Enter key to return to main menu");
                        Console.ReadLine();
                    }
                    else if (_transactionsRepository.HasMemberAlreadyRentedBook(memberId, bookId)) 
                    {

                        Console.WriteLine($"Member allready owes one book with the same ID");
                        Console.WriteLine();
                        Console.WriteLine("Press Enter key to return to main menu");
                        Console.ReadLine();

                    }
                    else
                    {
                        _transactionsRepository.CreateTransaction(memberId, bookId);
                        _membersRepository.AddRentedBookToMember(memberId);
                        Console.WriteLine($"Book with ID number {bookId} has been rented to member with ID number {memberId}");

                        Console.WriteLine();
                        Console.WriteLine("Press Enter key to return to main menu");
                        Console.ReadLine();

                    }
                }
                else 
                {

                    bool bookExists = _booksRepository.DoesBookExistById(bookId);
                    bool memberExists = _membersRepository.DoesMemberExistById(memberId);

                    Console.WriteLine("Member and/or book not found. Please check the information you provided and try again.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
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
                Console.Clear();


                if (_membersRepository.DoesMemberExistById(memberId) && _booksRepository.DoesBookExistById(bookId))

                {
                    
                    if (_transactionsRepository.DoesTransactionExist(memberId, bookId))
                    {
                        _transactionsRepository.UpdateTransaction(memberId, bookId);
                        _membersRepository.RemoveRentedBookFromMember(memberId);
                        Console.WriteLine("Book returned to inventory");
                        Console.WriteLine();
                        Console.WriteLine("Press Enter key to return to main menu");
                        Console.ReadLine();
                    }
                    else 
                    {
                        Console.WriteLine($"This member doesn't seem to owe a book with ID {bookId}.");
                        Console.WriteLine();
                        Console.WriteLine("Press Enter key to return to main menu");
                        Console.ReadLine();
                    }
                }
                else 
                {
                    Console.WriteLine("Member and/or book not found. Please check the information you provided and try again.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
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
                Console.Clear();

                if (_membersRepository.DoesMemberExistById(memberId))
                {
                    _membersRepository.DeleteMember(memberId);
                    Console.WriteLine($"Member with id number {memberId} has been deleted.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();
                }
                else
                {

                    Console.WriteLine("Member not found. Please check the information you provided and try again.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter key to return to main menu");
                    Console.ReadLine();

                }
            }
            catch (Exception ex)
            {


                Console.WriteLine($"An error occurred during deletion: {ex.Message}");


            }
        }
        

    }
}
