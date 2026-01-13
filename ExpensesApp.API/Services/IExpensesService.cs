using ExpensesApp.API.Models;

namespace ExpensesApp.API.Services;

public interface IExpensesService
{
    Task<List<Expense>> GetExpensesAsync();
    Task<Expense?> GetExpenseByIdAsync(int id);
    Task<Expense> AddExpenseAsync(Expense expense);
    Task<Expense?> UpdateExpenseAsync(Expense expense);
    Task<bool> DeleteExpenseAsync(int id);
}