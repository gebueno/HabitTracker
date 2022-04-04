using HabitTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Business
{
    class HabitBusiness
    {
        public HabitBusiness()
        {
            
        }

        public void MainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Type 0 to Close Application");
            Console.WriteLine("Type 1 to View All Records");
            Console.WriteLine("Type 2 to Insert Record");
            Console.WriteLine("Type 3 to Delete Record");
            Console.WriteLine("Type 4 to Update Record");

            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 0:
                    CloseProgram();
                    break;
            }
        }

        private void CloseProgram()
        {
            Console.WriteLine("The program will be closed! Are you sure (Y/N)");
            string exitInput = Convert.ToString(Console.ReadLine());

            if (exitInput.Equals("Y") || exitInput.Equals("y"))
            {
                Environment.Exit(0);
            }
            else if(exitInput.Equals("N") || exitInput.Equals("n"))
            {
                Console.Clear();
                HabitBusiness habit = new HabitBusiness();
                habit.MainMenu();
            }
            else 
            {
                Console.WriteLine("Oops, you need to type Y or N");
                CloseProgram();
            }
        }

        private void Select()
        {


        }
    }
}
