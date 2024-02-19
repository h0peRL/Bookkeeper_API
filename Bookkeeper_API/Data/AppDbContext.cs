using Bookkeeper_API.Model;
using Bookkeeper_API.Model.AccountTypes;
using Bookkeeper_API.Model.UserManagement;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Bookkeeper_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookingRecord> Bookings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ActiveAccount> ActiveAccounts { get; set; }

        public DbSet<PassiveAccount> PassiveAccounts { get; set; }

        public DbSet<IncomeAccount> IncomeAccounts { get; set; }

        public DbSet<ExpenseAccount> ExpenseAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure mapping for User entity
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v), // Convert IUserRoleState to JSON string
                    v => JsonConvert.DeserializeObject<IUserRoleState>(v) !); // Convert JSON string back to IUserRoleState

            modelBuilder.Entity<BookingRecord>()
                .Property(b => b.Amount)
                .HasPrecision(2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
