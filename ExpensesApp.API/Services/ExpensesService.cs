using ExpensesApp.API.Data;
using ExpensesApp.API.Models;

namespace ExpensesApp.API.Services;

public class ExpensesService(AppDbContext dbContext):IExpensesService
{
    
    public List<Expense> GetExpenses()
    {
        return dbContext.Expenses.ToList();
    }

    public Expense? GetExpenseById(int id) => dbContext.Expenses.FirstOrDefault(x => x.Id == id);

    public Expense AddExpense(Expense expense)
    {
        dbContext.Expenses.Add(expense);
        dbContext.SaveChanges();
        return expense;
    }

    public Expense? UpdateExpense(Expense expense)
    {
        var expenseToUpdate = dbContext.Expenses.FirstOrDefault(x => x.Id == expense.Id);

        if (expenseToUpdate != null)
        {
            expenseToUpdate.Type = expense.Type;
            expenseToUpdate.Description = expense.Description;
            expenseToUpdate.Amount = expense.Amount;
            expenseToUpdate.Date = expense.Date;
            expenseToUpdate.Category = expense.Category;
            
            dbContext.Expenses.Update(expenseToUpdate);
            dbContext.SaveChanges();
        }
        
        return expenseToUpdate;
    }

    public bool DeleteExpense(int id)
    {
        var dbRecord = dbContext.Expenses.FirstOrDefault(n => n.Id == id);

        if (dbRecord == null) return false;
        
        dbContext.Expenses.Remove(dbRecord);
        dbContext.SaveChanges();
        
        return true;
    }
}