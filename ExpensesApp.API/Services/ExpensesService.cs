using ExpensesApp.API.Data;
using ExpensesApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.API.Services;

public class ExpensesService(AppDbContext dbContext):IExpensesService
{
    
    public async Task<List<Expense>> GetExpensesAsync()
    {
        return await dbContext.Expenses
            .Include(n => n.User)
            .ToListAsync();
    }

    public async Task<Expense?> GetExpenseByIdAsync(int id) => await dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Expense> AddExpenseAsync(Expense expense)
    {
        await dbContext.Expenses.AddAsync(expense);
        await dbContext.SaveChangesAsync();
        return expense;
    }

    public async Task<Expense?> UpdateExpenseAsync(Expense expense)
    {
        var expenseToUpdate = await dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == expense.Id);

        if (expenseToUpdate != null)
        {
            expenseToUpdate.Type = expense.Type;
            expenseToUpdate.Description = expense.Description;
            expenseToUpdate.Amount = expense.Amount;
            expenseToUpdate.Date = expense.Date;
            expenseToUpdate.Category = expense.Category;
            
            dbContext.Expenses.Update(expenseToUpdate);
            await dbContext.SaveChangesAsync();
        }
        
        return expenseToUpdate;
    }

    public async Task<bool> DeleteExpenseAsync(int id)
    {
        var dbRecord = await dbContext.Expenses.FirstOrDefaultAsync(n => n.Id == id);

        if (dbRecord == null) return false;
        
        dbContext.Expenses.Remove(dbRecord);
        await dbContext.SaveChangesAsync();
        
        return true;
    }
}