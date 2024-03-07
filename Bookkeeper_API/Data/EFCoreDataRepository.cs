using System.Data;
using Bookkeeper_API.Model;
using Bookkeeper_API.Model.AccountTypes;
using Bookkeeper_API.Model.UserManagement;
using Bookkeeper_API.Model.UserManagement.RoleStates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bookkeeper_API.Data
{
    public class EFCoreDataRepository : IDataRepository
    {
        private readonly AppDbContext _db;

        public EFCoreDataRepository(AppDbContext dbContext)
        {
            _db = dbContext;

            // check if seeding is needed

            if (!_db.IncomeAccounts.Any())
            {
                SeedData();
            }
        }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void AddBookingRecord(BookingRecord record)
        {
            throw new NotImplementedException();
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
            var activeAccounts = _db.ActiveAccounts.ToList();
            var passiveAccounts = _db.PassiveAccounts.ToList();
            List<Account> accounts = new List<Account>();
            accounts.AddRange(activeAccounts);
            accounts.AddRange(passiveAccounts);
            return accounts;
        }

        public IEnumerable<Account> GetIncomeStatementAccounts()
        {
            var incomeAccounts = _db.IncomeAccounts.ToList();
            var expenseAccounts = _db.ExpenseAccounts.ToList();
            List<Account> accounts = new List<Account>();
            accounts.AddRange(incomeAccounts);
            accounts.AddRange(expenseAccounts);
            return accounts;
        }

        public User GetUserById(int userId)
        {
            return _db.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _db.Users.FirstOrDefault(u => u.Username == username);
        }

        private void SeedData()
        {
            DataSet set = new DataSet();
            SeedAccounts();
        }

        private void SeedAccounts()
        {
            using IDbContextTransaction transaction = _db.Database.BeginTransaction();
            Dictionary<int, string> dictionary = ImportAccountsFromCSV();

            foreach (KeyValuePair<int, string> kvp in dictionary)
            {

                switch (kvp.Key)
                {
                    case >= 3000 and <= 3999:
                        _db.IncomeAccounts.Add(new IncomeAccount(kvp.Key, kvp.Value)
                        {
                            DataRepository = this
                        });
                        break;
                    case >= 4000 and <= 4999:
                        _db.ExpenseAccounts.Add(new ExpenseAccount(kvp.Key, kvp.Value)
                        {
                            DataRepository = this
                        });
                        break;
                }
            }
            // got the idea for this fix from https://stackoverflow.com/questions/40896047/how-to-turn-on-identity-insert-in-net-core
            _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Account ON");
            _db.SaveChanges();
            _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Account OFF");
            transaction.Commit();
        }

        private static Dictionary<int, string> ImportAccountsFromCSV()
        {
            string path = @"./account_chart.csv";
            Dictionary<int, string> accountValues = new();

            using var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine()
                              ?? throw new Exception("Reading null line from CSV-File.");
                string[] values = line.Split(";");

                if (values.Length != 2)
                {
                    throw new Exception("Line didn't contain at least 2 values.");
                }

                _ = int.TryParse(values[0], out int id);
                string name = values[1];

                if (accountValues.ContainsKey(id))
                {
                    throw new Exception($"Account with Id {id} already exists in dictionary!");
                }

                accountValues.Add(id, name);
            }

            return accountValues;
        }
    }
}
