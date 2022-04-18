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
                    Insert();
                    break;

                case 3:
                    Delete();
                    break;

                case 4:
                    Update();
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
            else if (exitInput.Equals("N") || exitInput.Equals("n"))
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
            Console.Clear();
            HabitRepository habitRepository = new();
            List<Habit> records = habitRepository.GetList();

            if(records != null)
            {
                foreach (var item in records)
                {
                    Console.WriteLine($"Id: {item.Id} - Record date: {item.Date} - Decription:  {item.Description} - Quantity: {item.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("There is no records yet.");
                ReturnToMenu();
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

        private void Insert()
        {
            Console.WriteLine("Insert the number of times you want to do this habit");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert a short description of your habit");
            string description = Console.ReadLine();

            HabitRepository habitRepository = new HabitRepository();
            habitRepository.Insert(DateTime.Now.ToString(), quantity, description);

            Console.Clear();
            MainMenu();
        }

        private void Delete()
        {
            Console.WriteLine("Insert the habit Id you want to delete");
            int habitId = Convert.ToInt32(Console.ReadLine());

            HabitRepository habitRepository = new HabitRepository();
            habitRepository.Get(habitId);

            Console.WriteLine("Are you sure you want to delete this habit? (Y/N)");
            string deleteConfirmation = Console.ReadLine();

            if (deleteConfirmation == "y" || deleteConfirmation == "Y")
            {
                habitRepository.Delete(habitId);
            }
            else if (deleteConfirmation == "n" || deleteConfirmation == "N")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Oops, you need to type Y or N, press any key to go to menu");
                Console.ReadKey();
                MainMenu();
            }
        }

        private void Update()
        {
            Console.WriteLine("Insert the habit Id you want to update: ");
            int habitId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert the number of times you want to do this habit");
            int quantityUpdated = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert a short description of your habit");
            string descriptioUpdated = Console.ReadLine();

            Console.WriteLine("Do you confirm the changes? (Y/N)");
            Console.WriteLine($"Decription:  {descriptioUpdated} - Quantity: {quantityUpdated}");
            string updateConfirmation = Console.ReadLine();

            HabitRepository habitRepository = new HabitRepository();

            if (updateConfirmation == "y" || updateConfirmation == "Y")
            {
                habitRepository.Update(habitId, quantityUpdated, descriptioUpdated);

                Console.WriteLine("Your habit has been updated!");
                ReturnToMenu();
            }
            else if (updateConfirmation == "n" || updateConfirmation == "N")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Oops, you need to type Y or N, press any key to go to menu");
                Console.ReadKey();
                MainMenu();
            }
        }
    }
}
