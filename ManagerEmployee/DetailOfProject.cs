using ProjectApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEmployee
{
    internal class Project
    {   

        private DetailOfProject project = new DetailOfProject();
        private Staff staff  = new Staff();
        private Manager manager = new Manager();
        
        

        public Project(Manager manager, Staff staff,DetailOfProject projectInfor) {
            this.manager = manager;
            this.staff = staff;
            this.project = projectInfor;
        }
        public void showAllInformation()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            project.detailOfProject();
            manager.showInfo();                    
            staff.showInfo();
        }

    }
}
