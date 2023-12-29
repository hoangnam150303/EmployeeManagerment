using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployee
{
    internal class DetailOfProject
    {
        private List<DetailOfProject> projectList = new List<DetailOfProject>();
        //Create variables
        private string id;
        private string name;
        private int startDay;
        private int startMonth;
        private int endDay;
        private int endMonth;
        private string description;

        //Create methods getter and setter
        public string Id { get {return id; } set {id = value; } }
        public string Description { get { return description; }  private set { description = value; } }
        public string Name { get { return name; } private set { name = value; } }
        public int StartDay { get { return startDay; } private set { startDay = value; } }
        public int StartMonth { get { return startMonth; } private set { startMonth = value; } }
    
        public int EndDay { get { return endDay; }private set { endDay = value; } }
        public int EndMonth { get { return endMonth; } private set { endMonth = value; } }
  

        //Create a constructor
        public DetailOfProject( string id,string name, int startDay, int endDay, string description, int startMonth, int endMonth) {
            Id = id;
            Name = name;
            StartDay = startDay;
            EndDay = endDay;
            Description = description;
            StartMonth = startMonth;
            EndMonth = endMonth;
        }
        public DetailOfProject() {
                
        }
        //Create method addProject
        public void addProject()
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
                        int numID = projectList.FindIndex(project =>  project.Id == addId);
                        if (numID != -1)
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
                    Console.WriteLine("Enter start Month: ");
                    if (int.TryParse(Console.ReadLine(), out int addStartMonth))
                    {
                        if (addStartMonth == null)
                        {
                            throw new Exception("Please enter month");
                        }
                        else if (addStartMonth > 12 || addStartMonth < 1)
                        {
                            throw new Exception("Invalid month");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid data");
                    }
                    Console.WriteLine("Enter start day: ");
                    if (int.TryParse(Console.ReadLine(), out int addStartDay))
                    {
                        if (addStartDay == null)
                        {
                            throw new Exception("Please enter day");

                        }else if (addStartMonth == 2)
                            {

                                if (addStartDay > 29 || addStartDay < 1)
                                {
                                    throw new Exception("Invalid day in Febuary");
                                }
                            }
                        else if (addStartMonth == 1 || addStartMonth == 3 || addStartMonth == 5 || addStartMonth == 7 || addStartMonth == 8 || addStartMonth == 10 || addStartMonth == 12)
                        {
                            if(addStartDay >31 || addStartDay < 1)
                            {
                                throw new Exception($"Invalid day in month");
                            }
                        }
                        else if (addStartMonth == 4 || addStartMonth == 6 || addStartMonth == 9 || addStartMonth == 11 )
                        {
                            if (addStartDay > 30 || addStartDay < 1)
                            {
                                throw new Exception($"Invalid day in month ");
                            }
                        }
                        
                        }
                    else
                    {
                        throw new Exception("Invalid data");
                    }

                    Console.WriteLine("Enter end Month: ");
                    if (int.TryParse(Console.ReadLine(), out int addEndMonth))
                    {
                        if (addEndMonth == null)
                        {
                            throw new Exception("Please enter month");
                        }
                        else if (addStartMonth > 12 || addEndMonth < 1)
                        {
                            throw new Exception("Invalid month");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid data");
                    }
                    Console.WriteLine("Enter end day: ");
                    if (int.TryParse(Console.ReadLine(), out int addEndDay))
                    {
                        if (addEndDay == null)
                        {
                            throw new Exception("Please enter day");

                        }
                        else if (addEndMonth == 2)
                        {

                            if (addEndDay > 29 || addEndDay < 1)
                            {
                                throw new Exception("Invalid day in Febuary");
                            }
                        }
                        else if (addEndMonth == 1 || addEndMonth == 3 || addEndMonth == 5 || addEndMonth == 7 || addEndMonth == 8 || addEndMonth == 10 || addEndMonth == 12)
                        {
                            if (addEndDay > 31 || addEndDay < 1)
                            {
                                throw new Exception($"Invalid day in month ");
                            }
                        }
                        else if (addEndMonth == 4 || addEndMonth == 6 || addEndMonth == 9 || addEndMonth == 11)
                        {
                            if (addEndDay > 30 || addEndDay < 1)
                            {
                                throw new Exception($"Invalid day in month ");
                            }
                        }

                    }
                    else
                    {
                        throw new Exception("Invalid data");
                    }
                    Console.WriteLine("Enter Descrition: ");
                    string addDescription = Console.ReadLine();
                    if (string.IsNullOrEmpty(addDescription))
                    {
                        throw new Exception("ID cannot be empty.");
                    }

                    DetailOfProject newProject = new DetailOfProject(addId, addName, addEndDay, addEndDay, addDescription,addStartMonth,addEndMonth);
                    add(newProject);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Project added successfully.");
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
        //create method removeProject
        public void removeProject()
        {
            try
            {
                Console.WriteLine("ID of staff you want to remove: ");
                string idClear = Console.ReadLine();

                if (idClear != null)
                {
                    int numberID = projectList.FindIndex(project => project.Id == idClear);
                    if (numberID != -1)
                    {
                        projectList.RemoveAt(numberID);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Remove success");
                    }
                    else
                    {
                        Console.WriteLine("Project not found.");
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
        //Create method add
        public void add(DetailOfProject p)
        {
            projectList.Add(p);
        }

        // Create method detaiOfProject
        public void detailOfProject()
        {
            if (projectList == null)
            {
                Console.WriteLine("No Data!");
            }
            foreach (DetailOfProject project in projectList)
                {
                    Console.WriteLine($"Name: {project.Name}, Start: {project.StartDay}/{project.StartMonth}, End: {project.EndDay}/{project.EndMonth}, Description: {project.Description}");
                }
          
        }
      
    }
}
