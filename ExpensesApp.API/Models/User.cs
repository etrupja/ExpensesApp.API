namespace ExpensesApp.API.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    
    //navigationproperty
    public List<Expense> Expenses { get; set; }
}