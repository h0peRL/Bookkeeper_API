using Bookkeeper_API.Model;
using Bookkeeper_API.Model.UserManagement;

namespace Bookkeeper_API.Data
{
    public class EFCoreDataRepository : IDataRepository
    {
        private readonly AppDbContext _db;

        public EFCoreDataRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public void AddBookingRecord(BookingRecord record)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void AuthorizeNewUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void DisapproveExistingUser(int userId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
