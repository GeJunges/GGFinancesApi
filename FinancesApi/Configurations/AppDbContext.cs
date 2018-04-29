using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Configirations {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ExpenseDate> ExpensesDate { get; set; }
        public DbSet<ExpenseDetails> ExpensesDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Expense>()
                .HasIndex("Name", "Budget")
                .IsUnique();
            modelBuilder.Entity<ExpenseDate>()
                .HasIndex("ExpenseId", "Date")
                .IsUnique();

            modelBuilder.Entity<Detail>()
                .HasIndex("Name")
                .IsUnique(); 
            modelBuilder.Entity<ExpenseDetails>()
                .HasIndex("ExpenseDateId", "DetailId")
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}