using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Configirations {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

       public DbSet<User> Users {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>();
            base.OnModelCreating(modelBuilder);
        }
    }
}