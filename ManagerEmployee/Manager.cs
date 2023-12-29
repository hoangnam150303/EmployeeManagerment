
using ProjectApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployee
{
    // class Manger is subclass of class Person and IMenu
    internal class Manager : Employee,IMenu
    {
        //Create variables instance and personlist with type Manager and DetailOfProject
        private static Manager instance;
        private List<Manager> managerList = new List<Manager>();   
       
        //Create constructor with base from class Person
        public Manager(string id, string name, int age, int phone, string address, double salary):base(id, name, age, phone, address, salary)
        {
            
        }
        public Manager()
        {

        }
        
       
        //create method getInstance with type Manager
        public static Manager getInstance()
        {
            if (instance == null)
            {
                instance = new Manager();
            }
            return instance;
        }
        // create method showInfor override from showInfor of class Person
        public override void showInfo()
        {
            
            
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("======Manager List=======");
                foreach (Manager manager in managerList)
                {
                    Console.WriteLine($" ID: {manager.Id}\n Name: {manager.Name} \n Age: {manager.Age}\n Phone: 0{manager.Phone}\n Address: {manager.Address}\n Salary: {manager.Salary} ");
                }
            
           
        }

        public void add(Manager manager)
        {
            managerList.Add(manager);
        }

        public void addManager()
        {

            while (true)
            {
                if (instance == null)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                   
                        try
                        {
                            Console.WriteLine("Enter ID: ");
                            string addId = Console.ReadLine();
                            if (string.IsNullOrEmpty(addId))
                            {
                                throw new Exception("ID cannot be empty.");
                            }

                            Console.WriteLine("Enter Name: ");
                            string addName = Console.ReadLine();
                            if (string.IsNullOrEmpty(addName))
                            {
                                throw new Exception("Name cannot be empty.");
                            }

                            Console.WriteLine("Age: ");
                            if (int.TryParse(Console.ReadLine(), out int addAge))
                            {
                                if (addAge <= 0)
                                {
                                    throw new Exception("Age must be a positive number.");
                                }
                                else if (addAge > 70)
                                {
                                    throw new Exception("The manager is too old to work here!");
                                }
                                else if (addAge == null)
                                {
                                    throw new Exception("Age cannot be empty");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new Exception("Invalid age input.");
                            }

                            Console.WriteLine("Enter Phone number: ");
                            if (int.TryParse(Console.ReadLine(), out int addPhone))
                            {
                              
                                if (addPhone == null)
                                {
                                    throw new Exception("Phone cannot be empty");
                                }
                            else if (addPhone.ToString().Length < 10 && addPhone.ToString().Length > 11)
                            {
                                throw new Exception("Invalid phone number");
                            }
                        }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new Exception("Invalid phone input.");
                            }

                            Console.WriteLine("Enter address: ");
                            string addAddress = Console.ReadLine();
                            if (string.IsNullOrEmpty(addAddress))
                            {
                                throw new Exception("Address cannot be empty.");
                            }

                            Console.WriteLine("Enter salary: ");
                            if (double.TryParse(Console.ReadLine(), out double addSalary))
                            {
                                if (addSalary < 0)
                                {
                                    throw new Exception("Salary must be a non-negative number.");
                                }
                                else if (addSalary == null)
                                {
                                    throw new Exception("Salary cannot be empty");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new Exception("Invalid salary input.");
                            }
                            Manager newManager = new Manager(addId, addName, addAge, addPhone, addAddress, addSalary);
                            add(newManager);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Manager added successfully.");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }                
                else if (instance != null)
                {
                    throw new Exception("This program has only one manager");
                    
                }
            }
        }

        public void removeManager()
        {
            try
            {
                Console.WriteLine("ID of staff you want to remove: ");
                string idClear = Console.ReadLine();

                if (idClear != null)
                {
                    int numberID = managerList.FindIndex(manager => manager.Id == idClear);
                    if (numberID != -1)
                    {
                        managerList.RemoveAt(numberID);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Remove success!");
                        instance = null;
                    }
                    else
                    {
                        Console.WriteLine("Manager not found.");

                    }
                }
                else
                {
                    throw new Exception("Invalid number");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("=====Menu of Manager====");
            Console.WriteLine("1. Add Manager");
            Console.WriteLine("2. Add Staff");
            Console.WriteLine("3. Add Project");
            Console.WriteLine("4. Remove Manager");
            Console.WriteLine("5. Remove Staff");
            Console.WriteLine("6. Remove Project");
            Console.WriteLine("7. Display all Information");
            Console.WriteLine("8. Exit");
            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.White;
        }







    }
}

