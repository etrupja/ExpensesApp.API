using ExpensesApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.API.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options):base(options)
    {}
    
    public DbSet<Expense> Expenses { get; set; }

    public DbSet<User> Users { get; set; }

}