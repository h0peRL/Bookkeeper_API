using Bookkeeper_API.Model;
using Bookkeeper_API.Model.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace Bookkeeper_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<BookingRecord> Bookings { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
