using ProjectApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployee
{
  public abstract class Employee
    {
        //Create variables
        private string id;
        private string name;
        private int age;
        private int phone;
        private string address;
        private double salary;
        //Create get/set for variables
        public string Id { get { return id; } private set { id = value; } }
        public string Name { get { return name; }private set { name = value; } }
        public int Age { get { return age; } private set { age = value; } }
        public int Phone { get { return phone; } private set { phone = value; } }
        public string Address { get { return address; } private set { address = value; } }
        public double Salary { get { return salary; }private set { salary = value; } }

        //Create constructor
       public Employee() { }
        public Employee(string id, string name, int age, int phone, string address, double salary)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            Address = address;
            Salary = salary;
        }

        //Create abstract method showInfor
        public abstract void showInfo();

        
    }
}
