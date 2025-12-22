namespace ExpensesApp.API.Dtos;

public class ExpenseRequestDto
{
    public DateTime Date { get; set; }
    public required string Type { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
}