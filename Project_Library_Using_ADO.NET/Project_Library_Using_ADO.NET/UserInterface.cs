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
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Welcome User");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Please choose one of the following options by typing the appropriate number.");
                    Console.WriteLine();
                    Console.WriteLine("1) Search Book by ID or Title");
                    Console.WriteLine("2) Search all books with at least one rented copy");
                    Console.WriteLine("3) Search all books with no rented copies");
                    Console.WriteLine("4) Present all Titles with available copies");
                    Console.WriteLine("5) Complete Inventory List");
                    Console.WriteLine("6) Insert new Book profile");
                    Console.WriteLine("7) Remove book copies from inventory");
                    Console.WriteLine("8) Search Member by ID or Full Name");
                    Console.WriteLine("9) Insert new Member profile");
                    Console.WriteLine("8) Rent book to member");
                    Console.WriteLine("9) Return book from member");
                    Console.WriteLine("10) Delete member profile");
                    string input = Console.ReadLine();

                    switch (input) 
                    {
                        case "1": 
                            {
                                Console.WriteLine("Please type the ID or full title of the book you are looking for:");
                                string userInput = Console.ReadLine();
                                int bookId;
                                if (int.TryParse(userInput, out bookId))
                                {
                                    _application.SearchBook(bookId);
                                }
                                else if(userInput.ToUpper()) 
                                { 
                                
                                }
                                break;
                            }
                        default:
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
