using Bookkeeper_API.Data;

namespace Bookkeeper_API.Tests.TestObjectClasses
{
    internal class TestDataRepository : IDataRepository
    {
        private TestDataSeeder seeder;
        private List<BookingRecord> bookingRecords = new();
        private List<User> users = new();
        private List<Account> accounts = new();

        public TestDataRepository()
        {
            seeder = new TestDataSeeder(this);
        }

        public void SeedAll()
        {
            seeder.SeedAccounts();
            seeder.SeedBookingRecords();
            seeder.SeedUsers();
        }

        public void SeedAccounts()
        {
            seeder.SeedAccounts();
        }

        public void SeedBookingRecords()
        {
            seeder.SeedBookingRecords();
        }

        public void SeedUsers()
        {
            seeder.SeedUsers();
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public void AddBookingRecord(BookingRecord record)
        {
            bookingRecords.Add(record);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void AuthorizeNewUser(User user)
        {
            user.SetRole(new AuthorizedUserRoleState());
        }

        public void DisapproveExistingUser(User user)
        {
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
            return accounts.FindAll(a => a.Id.ToString().StartsWith('3') || a.Id.ToString().StartsWith('4'));
        }

        public User GetUserById(int userId)
        {
            User user = users.Find(u => u.Id == userId)
                ?? throw new Exception($"No user with Id {userId} was found.");

            return user;
        }

        public User GetUserByUsername(string username)
        {
            return users.Find(u => u.Username == username)
                ?? throw new Exception($"No user with username {username} was found.");
        }
    }
}
