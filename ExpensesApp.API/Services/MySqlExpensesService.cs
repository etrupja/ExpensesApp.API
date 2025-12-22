using ExpensesApp.API.Data;
using ExpensesApp.API.Models;

namespace ExpensesApp.API.Services;

public class MySqlExpensesService:IExpensesService
{
    public List<Expense> GetExpenses()
    {
        return FakeDb._expenses;
    }

    public Expense? GetExpenseById(int id) => FakeDb._expenses.FirstOrDefault(x => x.Id == id);

    public Expense AddExpense(Expense expense)
    {
        FakeDb._expenses.Add(expense);
        return expense;
    }

    public Expense? UpdateExpense(Expense expense)
    {
        var expenseToUpdate = FakeDb._expenses.FirstOrDefault(x => x.Id == expense.Id);

        if (expenseToUpdate != null)
        {
            expenseToUpdate.Type = expense.Type;
            expenseToUpdate.Description = expense.Description;
            expenseToUpdate.Amount = expense.Amount;
            expenseToUpdate.Date = expense.Date;
            expenseToUpdate.Category = expense.Category;
        }
        
        return expenseToUpdate;
    }

    public bool DeleteExpense(int id)
    {
        var dbRecord = FakeDb._expenses.FirstOrDefault(n => n.Id == id);

        if (dbRecord == null) return false;
        
        FakeDb._expenses.Remove(dbRecord);
        return true;
    }
}