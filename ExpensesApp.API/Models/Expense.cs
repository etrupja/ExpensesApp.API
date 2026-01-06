using System.ComponentModel.DataAnnotations;

namespace ExpensesApp.API.Models;

public class Expense
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    public required string Type { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string? ShortDescription { get; set; }
    public double Amount { get; set; }
}