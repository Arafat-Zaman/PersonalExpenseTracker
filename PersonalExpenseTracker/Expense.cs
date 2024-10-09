using System;

namespace PersonalExpenseTracker
{
    public class Expense
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }

        public Expense(DateTime date, string category, decimal amount)
        {
            Date = date;
            Category = category;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {Category}: ${Amount:F2}";
        }
    }
}
