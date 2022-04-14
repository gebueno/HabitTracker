using HabitTracker.Models;
using HabitTracker.Repositories;
using System;
using System.Collections.Generic;

namespace HabitTracker.Business
{
    class HabitBusiness
    {
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

                case 1:
                    GetList();
                    break;

                case 2:
                    InsertHabit();
                    break;

                case 3:
                    DeleteRecord();
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
                MainMenu();
            }
            else 
            {
                Console.WriteLine("Oops, you need to type Y or N");
                CloseProgram();
            }
        }

        private void GetList()
        {
            HabitRepository habitRepository = new();
            List<Habit> records = habitRepository.GetList();

            foreach(var item in records)
            {                
                Console.WriteLine($"Record date: {item.Date} - Decription:  {item.Description} - Quantity: {item.Quantity}");
            }

            ReturnToMenu();
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("Do you want to return to main menu? (Y/N)");
            string returnInput = Convert.ToString(Console.ReadLine());
            if (returnInput.Equals("Y") || returnInput.Equals("y"))
            {
                Console.Clear();
                MainMenu();
            }
            else if (returnInput.Equals("N") || returnInput.Equals("n"))
            {
                CloseProgram();
            }
            else
            {
                Console.WriteLine("Oops, you need to type Y or N");
                ReturnToMenu();
            }
        }

        private void InsertHabit()
        {
            Console.WriteLine("Insert the number of times you want to do this habit");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert a short description of your habit");
            string description = Console.ReadLine();

            HabitRepository habitRepository = new HabitRepository();
            habitRepository.Insert(DateTime.Now.ToString(), quantity, description );

            Console.Clear();
            MainMenu();
        }

        private void DeleteRecord()
        {
            Console.WriteLine("Insert the habit you want to delete");
            int habitId = Convert.ToInt32(Console.ReadLine());

            HabitRepository habitRepository = new HabitRepository();
            habitRepository.Get(habitId);

            Console.WriteLine("Are you sure you want to delet the habit? (Y/N)");
            string deleteConfirmation = Console.ReadLine();

            if(deleteConfirmation == "y" || deleteConfirmation == "Y")
            {
                habitRepository.Delete(habitId);
            }
            else if(deleteConfirmation == "n" || deleteConfirmation == "N")
            {
                MainMenu();
            }
            else {
                Console.WriteLine("Oops, you need to type Y or N, press any key to go to menu");
                Console.ReadKey();
                MainMenu();
            }
        }
    }
}
