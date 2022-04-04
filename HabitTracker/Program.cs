using System;
using HabitTracker.Business;

namespace HabitTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            HabitBusiness habit = new HabitBusiness();
            habit.MainMenu();
        }
    }
}
