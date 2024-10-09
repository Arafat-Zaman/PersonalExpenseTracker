using System;
using System.Collections.Generic;
using System.IO;

namespace PersonalExpenseTracker
{
    public class ExpenseManager
    {
        private List<Expense> expenses;
        private const string DataFile = "data.txt";

        public ExpenseManager()
        {
            expenses = new List<Expense>();
            LoadExpenses();
        }

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
            SaveExpense(expense);
        }

        public decimal GetTotalExpenses(DateTime date)
        {
            decimal total = 0;

            foreach (var expense in expenses)
            {
                if (expense.Date.Date == date.Date)
                {
                    total += expense.Amount;
                }
            }

            return total;
        }

        private void LoadExpenses()
        {
            if (File.Exists(DataFile))
            {
                var lines = File.ReadAllLines(DataFile);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3 &&
                        DateTime.TryParse(parts[0], out var date) &&
                        decimal.TryParse(parts[2], out var amount))
                    {
                        expenses.Add(new Expense(date, parts[1], amount));
                    }
                }
            }
        }

        private void SaveExpense(Expense expense)
        {
            using (var writer = new StreamWriter(DataFile, true))
            {
                writer.WriteLine($"{expense.Date}|{expense.Category}|{expense.Amount}");
            }
        }
    }
}
