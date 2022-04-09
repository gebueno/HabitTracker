using System;
using HabitTracker.Business;
using HabitTracker.Repositories;

namespace HabitTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            HabitRepository habitDB = new HabitRepository();
            habitDB.CreateTable();

            HabitBusiness habit = new HabitBusiness( );
            habit.MainMenu();
        }
    }
}
