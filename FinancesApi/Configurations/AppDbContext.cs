using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Configirations {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Register> Registers { get; set; }
        public DbSet<IncomeDate> EntriesDate { get; set; }
        public DbSet<ExpenseDate> ExpensesDate { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ExpenseDetails> ExpensesDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Register>()
                .HasIndex("Name", "Budget")
                .IsUnique();

            modelBuilder.Entity<IncomeDate>()
                .HasIndex("RegisterId", "Date")
                .IsUnique();

            modelBuilder.Entity<ExpenseDate>()
                .HasIndex("RegisterId", "Date")
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