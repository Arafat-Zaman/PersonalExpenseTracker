using System;

namespace PersonalExpenseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var expenseManager = new ExpenseManager();
            Console.WriteLine("Welcome to the Personal Expense Tracker!");

            while (true)
            {
                Console.WriteLine("\n1. Add Expense");
                Console.WriteLine("2. View Total Expenses for Today");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddExpense(expenseManager);
                        break;
                    case "2":
                        ViewTotalExpenses(expenseManager);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private static void AddExpense(ExpenseManager expenseManager)
        {
            Console.Write("Enter the date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter the category (e.g., Food, Transport): ");
            string category = Console.ReadLine();

            Console.Write("Enter the amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            var expense = new Expense(date, category, amount);
            expenseManager.AddExpense(expense);
            Console.WriteLine("Expense added successfully!");
        }

        private static void ViewTotalExpenses(ExpenseManager expenseManager)
        {
            var today = DateTime.Today;
            decimal total = expenseManager.GetTotalExpenses(today);
            Console.WriteLine($"Total expenses for {today.ToShortDateString()}: ${total:F2}");
        }
    }
}
