using Microsoft.EntityFrameworkCore;

namespace csharp_expenses_manager.Models
{
    public class ExpensesContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public ExpensesContext(DbContextOptions<ExpensesContext> options)
            : base(options)
        {

        }
    }
}
