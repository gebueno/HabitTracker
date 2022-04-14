using System;

namespace HabitTracker.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
