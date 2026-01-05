using ExpensesApp.API.Models;

namespace ExpensesApp.API.Services;

public interface IExpensesService
{
    List<Expense> GetExpenses();
    Expense? GetExpenseById(int id);
    Expense AddExpense(Expense expense);
    Expense? UpdateExpense(Expense expense);
    bool DeleteExpense(int id);
}