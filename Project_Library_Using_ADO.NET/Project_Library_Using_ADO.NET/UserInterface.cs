
﻿using Domain.Entities;
using Library_Application.Interfaces;


namespace Library_Services
{
    public class UserInterface
    {
        private readonly IApplication _application;

        public UserInterface(IApplication application)
        {
                _application = application;
        }

        public void Menu() 
        {
            try
            {
                bool run = true;

                while (run) 
                {
                    Console.Clear();

                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Welcome User");
                    Console.WriteLine("--------------------------------------------");

                    Console.WriteLine();

                    Console.WriteLine("Please choose one of the following options by typing the appropriate number.");
                    Console.WriteLine();
                    Console.WriteLine("1) Search Book by ID or Title");
                    Console.WriteLine("2) Search all books with at least one rented copy");
                    Console.WriteLine("3) Search all books with no rented copies");

                    Console.WriteLine("4) Search all Titles with available copies");
                    Console.WriteLine("5) Complete Inventory List");
                    Console.WriteLine("6) Insert new Book profile");
                    Console.WriteLine("7) Add or Remove book copies from inventory");
                    Console.WriteLine("8) Search Member by ID or Full Name");
                    Console.WriteLine("9) Insert new Member profile");
                    Console.WriteLine("10) Rent book to member");
                    Console.WriteLine("11) Return book from member");
                    Console.WriteLine("12) Delete member profile");
                    Console.WriteLine("Type exit to leave");
                    string input = Console.ReadLine().Trim().ToUpper();


                    switch (input) 
                    {
                        case "1": 
                            {
                                Console.WriteLine("Please type the ID or full title of the book you are looking for:");

                                string userInput = Console.ReadLine().Trim();

                                int bookId;
                                if (int.TryParse(userInput, out bookId))
                                {
                                    _application.SearchBook(bookId);
                                }

                                else
                                {
                                    string bookTitle = userInput.ToUpper();
                                    _application.SearchBook(bookTitle);
                                }
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("Books that have at least one rented copy:");
                                Console.WriteLine("--------------------------------------------");
                                _application.SearchAllRentedBooks();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("Books that have no rented copies:");
                                Console.WriteLine("--------------------------------------------");
                                _application.SearchAllNotRentedBooks();
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("Books with available copies:");
                                Console.WriteLine("--------------------------------------------");
                                _application.SearchAllAvailableBooks();
                                break;
                            }
                        case "5": 
                            {
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("All Books:");
                                Console.WriteLine("--------------------------------------------");
                                _application.SearchAllBooks();
                                break;
                            }
                        case "6":
                            {

                                Console.Clear();


                                Books book = new Books();
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine("Please follow the instructions to create a new book profile:");
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine();
                                Console.WriteLine("Make sure to insert all relevant information as printed on the book itself!");
                                
                                Console.WriteLine("Please insert Title:");
                                book.Title = Console.ReadLine().Trim();

                                

                                Console.WriteLine("Please insert book Genre:");
                                book.Genre = Console.ReadLine().Trim();
                                

                                Console.WriteLine("Please insert book Description:");
                                book.Description = Console.ReadLine().Trim();
                                

                                Console.WriteLine("Please insert ISBN (13 digits):");
                                book.ISBN = Console.ReadLine().Trim();
                                

                                Console.WriteLine("Please insert number of copies:");
                                book.TotalCopies = Convert.ToInt32(Console.ReadLine().Trim());
                                

                                book.AvailableCopies = book.TotalCopies;
                                
                                _application.CreateNewBook(book);
                                break;
                            }
                        case "7":
                            int bookId1;
                            int addRemove;
                            string userInput1;
                            string userInput2;
                            Console.WriteLine("---------------------------------------------------------------");
                            Console.WriteLine("Add/Remove copies");
                            Console.WriteLine("---------------------------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Please enter your target book ID:");
                            userInput1 = Console.ReadLine().Trim();
                            
                            if (int.TryParse(userInput1, out bookId1))
                            {
                                Console.WriteLine("Please enter the amount of copies you wish to add by providing a possitive number. " +
                                    "Provide a negative number to remove copies");
                                Console.WriteLine();
                                Console.WriteLine("Number of copies to add/remove:");
                                userInput2 = Console.ReadLine().Trim();

                                if (int.TryParse(userInput2, out addRemove))
                                {
                                    _application.AddRemoveBookCopy(bookId1, addRemove);
                                }
                                else 
                                {
                                    Console.WriteLine("Please enter a valid number");
                                }

                            }
                            else 
                            { 
                                Console.WriteLine("Please enter a valid bookId"); 
                            }
                            break;
                        case "8":
                            {
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine("Search for member");
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine();
                                Console.WriteLine("Please type the ID or full name of the member you are looking for:");
                                string userInput3 = Console.ReadLine().Trim();
                                int memberId;
                                if (int.TryParse(userInput3, out memberId))
                                {
                                    _application.SearchMember(memberId);
                                }
                                else
                                {
                                    string fullName = userInput3.ToUpper();
                                    _application.SearchMember(fullName);
                                }
                                break;
                            }
                        case "9": 
                            {
                                Members member = new Members();
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine("Please follow the instructions to create a new member profile:");
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine();
                                Console.WriteLine("Please insert member First Name:");
                                member.FirstName = Console.ReadLine().Trim();
                                Console.Clear();

                                Console.WriteLine("Please insert member Last Name:");
                                member.LastName = Console.ReadLine().Trim();
                                Console.Clear();

                                Console.WriteLine("Please insert member Address:");
                                member.Address = Console.ReadLine().Trim();
                                Console.Clear();

                                Console.WriteLine("Please insert member phone number:");
                                member.Phone = Console.ReadLine().Trim();
                                Console.Clear();

                                Console.WriteLine("Please insert member e-mail:");
                                member.Email = Console.ReadLine().Trim();

                                _application.CreateMember(member);

                                Console.Clear();

                                break;
                            }
                        case "10":
                            {
                                int bookId;
                                int memberId;

                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine("Rent book to member");
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine();
                                
                                Console.WriteLine("Please provide target book ID number:");
                                string userInput4 = Console.ReadLine().Trim();
                                Console.Clear();

                                Console.WriteLine("Please provide target member ID number:");
                                string userInput5 = Console.ReadLine().Trim();
                                Console.Clear();

                                if (int.TryParse(userInput4, out bookId) && int.TryParse(userInput5, out memberId)) 
                                {
                                    _application.RentBookToMember(memberId, bookId);
                                }

                                
                                break;
                            }
                        case "11":
                            {
                                int bookId;
                                int memberId;

                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine("Return book from member");
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine();

                                Console.WriteLine("Please provide target book ID number:");
                                string userInput4 = Console.ReadLine().Trim();
                                Console.Clear();

                                Console.WriteLine("Please provide target member ID number:");
                                string userInput5 = Console.ReadLine().Trim();
                                Console.Clear();

                                if (int.TryParse(userInput4, out bookId) && int.TryParse(userInput5, out memberId))
                                {
                                    _application.ReturnBook(memberId, bookId);
                                }

                                break;
                            }
                        case "12":
                            {
                                int memberId;

                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine("Delete member");
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine();

                                Console.WriteLine("Please provide target member ID number:");
                                string userInput6 = Console.ReadLine().Trim();
                                Console.Clear();

                                if (int.TryParse(userInput6, out memberId)) 
                                {
                                    _application.HardDeleteMember(memberId);
                                }

                                break;
                            }
                        case "EXIT":
                            {
                                run = false;
                                Console.WriteLine("Exiting the application");
                                Console.ReadLine();

                                break;
                            }
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                            
                    }
                }       

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
