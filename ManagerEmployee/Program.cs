using ManagerEmployee;
using ProjectApplication;
using System.Security.Cryptography;

namespace program
{
    class Program
    {
        public static void Main(string[] args)
        {
           
            Manager manager = new Manager();
            Staff staff = new Staff();
            DetailOfProject project = new DetailOfProject();
            Project Project = new Project(manager, staff,project);
            IMenu menu;
            int input = 0;
            int choice;

            do
            {
                try
                {                   
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;                    
                    Console.WriteLine("1. ================================Login================================");
                    Console.WriteLine("2. ================================Exit=================================");
                    Console.WriteLine("Your choice: ");
                    input = int.Parse(Console.ReadLine());

                    if (input == 1)
                    {
                        try
                        {
                            Console.ForegroundColor= ConsoleColor.DarkCyan;
                            Console.WriteLine("Enter username: ");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter password: ");
                            string password = Console.ReadLine();

                            if (username == "manager"||username=="Manager" && password == "manager"||password=="Manager")
                            {
                                do
                                {                                   
                                    menu = new Manager();
                                    menu.menu();
                                    Console.WriteLine("Enter your choice: ");
                                    choice = int.Parse(Console.ReadLine());
                                    switch (choice)
                                    {
                                        case 1:
                                            manager.addManager();
                                            Manager.getInstance();
                                            break;
                                        case 2:
                                            staff.addStaff();
                                            break;
                                        case 3:
                                           project.addProject();
                                            break;
                                        case 4:
                                            manager.removeManager();
                                            break;
                                        case 5:
                                            staff.removeStaff();
                                            break;
                                        case 6:
                                            project.removeProject();
                                            break;
                                        case 7:
                                            Project.showAllInformation();
                                            break;
                                        case 8:
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("GoodBye!");
                                            break;
                                        default:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid number");
                                            break;
                                    }
                                } while (choice != 8);
                            }
                            else if (username == "staff"||username=="Staff" && password == "staff"||password=="Staff")
                            {
                                do
                                {
                                    menu = new Staff();
                                    menu.menu();
                                    Console.WriteLine("Enter your choice: ");
                                    choice = int.Parse(Console.ReadLine());
                                    switch (choice)
                                    {
                                        case 1:
                                            staff.showInfo();
                                            break;
                                        case 2:
                                            Console.WriteLine("GoodBye!");
                                            break;
                                        default:
                                            Console.WriteLine("Invalid number");
                                            break;
                                    }
                                } while (choice != 2);
                            }
                            else
                            {   
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new Exception("Wrong username, password!");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (input == 2)
                    {
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.WriteLine("Goodbye!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new Exception("Invalid number, please try again!");
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            } while (input != 2);
        }
    }
}