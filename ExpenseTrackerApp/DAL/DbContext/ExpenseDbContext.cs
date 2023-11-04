
using ExpenseTrackerApp.Models;
using System.Data.Entity;


namespace ExpenseTrackerApp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Expense> Expenses { get; set; }
    }
}