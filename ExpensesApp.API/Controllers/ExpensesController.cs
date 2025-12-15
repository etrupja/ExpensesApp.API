using ExpensesApp.API.Data;
using ExpensesApp.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.API.Controllers;

[EnableCors("AllowAll")]
[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    // GET
    [HttpGet("GetAllExpenses")]
    public IActionResult Index()
    {
        var result = FakeDb.GetAllExpenses();
        return Ok(result);
    }

    [HttpGet("GetExpense/{id}")]
    public IActionResult GetExpense(int id)
    {
        var expense = FakeDb.GetExpenseById(id);

        if(expense == null)
            return NotFound();

        return Ok(expense);
    }

    [HttpPost("AddExpense")]
    public IActionResult AddExpense([FromBody] Expense expense)
    {
        if (expense == null)
            return BadRequest("Expense data is required");

        if (string.IsNullOrWhiteSpace(expense.Type))
            return BadRequest("Type is required");

        if (string.IsNullOrWhiteSpace(expense.Category))
            return BadRequest("Category is required");

        if (expense.Amount <= 0)
            return BadRequest("Amount must be greater than 0");

        var addedExpense = FakeDb.AddExpense(expense);
        return CreatedAtAction(nameof(GetExpense), new { id = addedExpense.Id }, addedExpense);
    }

    [HttpPut("UpdateExpense/{id}")]
    public IActionResult UpdateExpense([FromBody] Expense expense, int id)
    {
        if (expense == null)
            return BadRequest("Expense data is required");

        if (string.IsNullOrWhiteSpace(expense.Type))
            return BadRequest("Type is required");

        if (string.IsNullOrWhiteSpace(expense.Category))
            return BadRequest("Category is required");

        if (expense.Amount <= 0)
            return BadRequest("Amount must be greater than 0");

        var updated = FakeDb.UpdateExpense(id, expense);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("DeleteExpense/{id}")]
    public IActionResult DeleteExpense(int id)
    {
        var deleted = FakeDb.DeleteExpense(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}