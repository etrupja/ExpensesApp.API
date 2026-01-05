using ExpensesApp.API.Data;
using ExpensesApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.API.Services;

public class MySqlExpensesService : IExpensesService
{
    private readonly ApplicationDbContext _context;

    public MySqlExpensesService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Expense> GetExpenses()
    {
        return _context.Expenses.ToList();
    }

    public Expense? GetExpenseById(int id)
    {
        return _context.Expenses.Find(id);
    }

    public Expense AddExpense(Expense expense)
    {
        _context.Expenses.Add(expense);
        _context.SaveChanges();
        return expense;
    }

    public Expense? UpdateExpense(Expense expense)
    {
        var expenseToUpdate = _context.Expenses.Find(expense.Id);

        if (expenseToUpdate != null)
        {
            expenseToUpdate.Type = expense.Type;
            expenseToUpdate.Description = expense.Description;
            expenseToUpdate.Amount = expense.Amount;
            expenseToUpdate.Date = expense.Date;
            expenseToUpdate.Category = expense.Category;

            _context.SaveChanges();
        }

        return expenseToUpdate;
    }

    public bool DeleteExpense(int id)
    {
        var dbRecord = _context.Expenses.Find(id);

        if (dbRecord == null) return false;

        _context.Expenses.Remove(dbRecord);
        _context.SaveChanges();
        return true;
    }
}