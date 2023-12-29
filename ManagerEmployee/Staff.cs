
using ProjectApplication;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployee
{
    //Class Staff is subclass of class Person and IMenu
   public class Staff:Employee,IMenu
    {
        //Create variable
        private string major;
        //Create a list
        private List<Staff> staffList = new List<Staff>();
     
        //Create methods getter and setter
        public string Major { get { return major; }  private set { major = value; } }
        
        //Create a constructor
        public Staff(string id, string name,int age,int phone,string address,double salary, string major):base(id, name, age, phone, address, salary)     
        {
            Major = major;
          
           
        }

        public Staff()
        {

        }

        //Create method addStaff
        public void add(Staff staff)
        {
            staffList.Add(staff);
        }    

        //Overrid method showInfor
        public override void showInfo() {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("======Staff List======");
            foreach (Staff staff in staffList)
            {
              
                Console.WriteLine($" ID:{staff.Id}\n Name: {staff.Name} \n Age: {staff.Age}\n Phone: 0{staff.Phone}\n Address: {staff.Address}\n Salary: {staff.Salary}\n Major: {staff.Major}\n");

             
            }
            Console.WriteLine("======================");
        }

        public void addStaff()
        {
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter ID: ");
                    string addId = Console.ReadLine();
                    if (string.IsNullOrEmpty(addId))
                    {
                        throw new Exception("ID cannot be empty.");
                    }else if(addId != null)
                    {
                        int numberID = staffList.FindIndex(staff => staff.Id == addId);
                        if (numberID != -1)
                        {
                            throw new Exception("Duplicate ID");
                        }
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
                        else if (addAge > 50)
                        {
                            throw new Exception("The staff is too old to work here!");
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
                        }else if(addPhone != null)
                        {
                           int phone = staffList.FindIndex(staff => staff.Phone ==  addPhone);
                            if (phone != -1)
                            {
                                throw new Exception("Duplicate phone number");
                            }
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

                    Console.WriteLine("Enter major: ");
                    string addMajor = Console.ReadLine();
                    if (string.IsNullOrEmpty(addMajor))
                    {
                        throw new Exception("Address cannot be empty.");
                    }
                    Staff newStaff = new Staff(addId,addName,addAge,addPhone,addAddress,addSalary,addMajor);
                    add(newStaff);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Staff added successfully.");
                    break;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public void removeStaff()
        {

            try
            {
                Console.WriteLine("ID of staff you want to remove: ");
                string idClear = Console.ReadLine();

                if (idClear != null)
                {
                    int numberID = staffList.FindIndex(staff => staff.Id == idClear);
                    if (numberID != -1)
                    {
                        staffList.RemoveAt(numberID);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Remove success");
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Staff not found.");
                        Console.ForegroundColor = ConsoleColor.White;
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=====Menu of Staff=====");
            Console.WriteLine("1. Display all information of Staff");
            Console.WriteLine("2. Exit");
            Console.WriteLine("=======================");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
