using ExpensesApp.API.Dtos;
using ExpensesApp.API.Models;
using ExpensesApp.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.API.Controllers;

[EnableCors("AllowAll")]
[ApiController]
[Route("api/[controller]")]
public class ExpensesController(IExpensesService expensesService) : ControllerBase
{
    // GET
    [HttpGet("GetAllExpenses")]
    public async Task<IActionResult> Index()
    {
        var result = await expensesService.GetExpensesAsync();
        return Ok(result);
    }

    [HttpGet("GetExpense/{id}")]
    public async Task<IActionResult> GetExpense(int id)
    {
        var expense = await expensesService.GetExpenseByIdAsync(id);
        if(expense == null)
            return NotFound();

        return Ok(expense);
    }

    [HttpPost("AddExpense")]
    public async Task<IActionResult> AddExpense([FromBody] ExpenseRequestDto expense)
    {
        if (expense == null)
            return BadRequest("Expense data is required");

        if (string.IsNullOrWhiteSpace(expense.Type))
            return BadRequest("Type is required");

        if (string.IsNullOrWhiteSpace(expense.Category))
            return BadRequest("Category is required");

        if (expense.Amount <= 0)
            return BadRequest("Amount must be greater than 0");
        
        //Mapping
        var newExpense = new Expense()
        {
            Type = expense.Type,
            Category = expense.Category,
            Amount = expense.Amount,
            Date = expense.Date,
            Description = expense.Description
        };
        
        var addedExpense = await expensesService.AddExpenseAsync(newExpense);
        return CreatedAtAction(nameof(GetExpense), new { id = addedExpense.Id }, addedExpense);
    }

    [HttpPut("UpdateExpense/{id}")]
    public async Task<IActionResult> UpdateExpense([FromBody] Expense expense, int id)
    {
        if (expense == null)
            return BadRequest("Expense data is required");

        if (string.IsNullOrWhiteSpace(expense.Type))
            return BadRequest("Type is required");

        if (string.IsNullOrWhiteSpace(expense.Category))
            return BadRequest("Category is required");

        if (expense.Amount <= 0)
            return BadRequest("Amount must be greater than 0");

        var updated = await expensesService.UpdateExpenseAsync(expense);
        return Ok(updated);
    }

    [HttpDelete("DeleteExpense/{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var deleted = await expensesService.DeleteExpenseAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}