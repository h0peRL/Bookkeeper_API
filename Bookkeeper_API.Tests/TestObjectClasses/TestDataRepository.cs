using Bookkeeper_API.Data;

namespace Bookkeeper_API.Tests.TestObjectClasses
{
    internal class TestDataRepository : IDataRepository
    {
        private List<BookingRecord> bookingRecords = new();
        private List<User> users = new();
        private List<Account> accounts = new();

        public void AddBookingRecord(BookingRecord record)
        {
            var seeder = new TestDataSeeder(this);

            seeder.SeedAccounts();
            seeder.SeedBookingRecords();
            seeder.SeedUsers();
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void AuthorizeNewUser(int userId)
        {
            User? user = users.Find(u => u.Id == userId)
                ?? throw new Exception($"No user with Id {userId} was found.");

            user.SetRole(new AuthorizedUserRoleState());
        }

        public void DisapproveExistingUser(int userId)
        {
            User? user = users.Find(u => u.Id == userId)
                ?? throw new Exception($"No user with Id {userId} was found.");

            user.SetRole(new NewUserRoleState());
        }

        public IEnumerable<BookingRecord> FindBookingRecordsForAccount(int accountId)
        {
            return bookingRecords.FindAll(a => a.DebitAccount.Id == accountId || a.CreditAccount.Id == accountId);
        }

        public Account GetAccountById(int accountId)
        {
            Account account = accounts.Find(a => a.Id == accountId)
                ?? throw new Exception($"No account with Id {accountId} was found.");

            return account;
        }

        public IEnumerable<Account> GetBalanceSheetAccounts()
        {
            return accounts.FindAll(a => a.Id.ToString().StartsWith('1') || a.Id.ToString().StartsWith('2'));
        }

        public IEnumerable<Account> GetIncomeStatementAccounts()
        {
            return accounts.FindAll(a => a.Id.ToString()[0] > 2);
        }

        public User GetUserById(int userId)
        {
            User user = users.Find(u => u.Id == userId)
                ?? throw new Exception($"No user with Id {userId} was found.");

            return user;
        }
    }
}
