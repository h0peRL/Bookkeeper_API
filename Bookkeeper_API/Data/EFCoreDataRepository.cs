using Bookkeeper_API.Model;
using Bookkeeper_API.Model.UserManagement;
using Bookkeeper_API.Model.UserManagement.RoleStates;
using Microsoft.EntityFrameworkCore;

namespace Bookkeeper_API.Data
{
    public class EFCoreDataRepository : IDataRepository
    {
        private readonly AppDbContext _db;

        public EFCoreDataRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void AddBookingRecord(BookingRecord record)
        {
            _db.Add(record);
            _db.SaveChanges();
        }

        public void AddUser(User user)
        {
            if (_db.Users.Any(u => u.Username == user.Username))
            {
                throw new InvalidOperationException("User already exists");
            }
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void AuthorizeNewUser(User user)
        {
            user.SetRole(new AuthorizedUserRoleState());
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void DisapproveExistingUser(User user)
        {
            user.SetRole(new NewUserRoleState());
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public IEnumerable<BookingRecord> FindBookingRecordsForAccount(int accountId)
        {
            return _db.Bookings.Where(b => b.DebitAccount.Id == accountId
            || b.CreditAccount.Id == accountId);
        }

        public Account GetAccountById(int accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetBalanceSheetAccounts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetIncomeStatementAccounts()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            return _db.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _db.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
