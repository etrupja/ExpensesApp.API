using ExpensesApp.API.Models;

namespace ExpensesApp.API.Data;

public static class FakeDb
{
    public static List<Expense> _expenses = new List<Expense>()
    {
        new ()
        {
            Id = 1,
            Category = "Expense",
            Description = "Expense",
            Amount = 12.00,
            Date = DateTime.UtcNow,
            Type = "expense"
        },
        new ()
        {
            Id = 2,
            Category = "Expense",
            Description = "Expense",
            Amount = 12.00,
            Date = DateTime.UtcNow,
            Type = "expense"
        },
        new ()
        {
            Id = 3,
            Category = "Income",
            Description = "Example income",
            Amount = 12.00,
            Date = DateTime.UtcNow,
            Type = "income"
        }
    };
}