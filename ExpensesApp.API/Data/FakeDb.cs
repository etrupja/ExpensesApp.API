using ExpensesApp.API.Models;

namespace ExpensesApp.API.Data;

public static class FakeDb
{
    private static List<Expense> _expenses = new List<Expense>()
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

    public static List<Expense> GetAllExpenses()
    {
        return _expenses;
    }

    public static Expense? GetExpenseById(int id)
    {
        return _expenses.FirstOrDefault(x => x.Id == id);
    }

    public static Expense AddExpense(Expense expense)
    {
        expense.Id = _expenses.Any() ? _expenses.Max(x => x.Id) + 1 : 1;
        _expenses.Add(expense);
        return expense;
    }

    public static bool UpdateExpense(int id, Expense updatedExpense)
    {
        var expense = _expenses.FirstOrDefault(x => x.Id == id);
        if (expense == null)
            return false;

        expense.Date = updatedExpense.Date;
        expense.Type = updatedExpense.Type;
        expense.Category = updatedExpense.Category;
        expense.Description = updatedExpense.Description;
        expense.Amount = updatedExpense.Amount;

        return true;
    }

    public static bool DeleteExpense(int id)
    {
        var expense = _expenses.FirstOrDefault(x => x.Id == id);
        if (expense == null)
            return false;

        _expenses.Remove(expense);
        return true;
    }
}