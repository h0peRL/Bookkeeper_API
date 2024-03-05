using Bookkeeper_API.Data;

namespace Bookkeeper_API.Tests.TestObjectClasses
{
    internal class TestDataSeeder
    {
        private readonly IDataRepository _repository;

        public TestDataSeeder(IDataRepository repository)
        {
            this._repository = repository;
        }

        public void SeedAccounts()
        {
            Dictionary<int, string> dictionary = ImportAccountsFromCSV();

            foreach (KeyValuePair<int, string> kvp in dictionary)
            {
                Account account = CreateAccount(kvp, _repository);
                _repository.AddAccount(account);
            }
        }

        public void SeedBookingRecords()
        {
            List<BookingRecord> bookings = new()
            {
                new BookingRecord(1, "test note", _repository.GetAccountById(1020), _repository.GetAccountById(1000), 100),
                new BookingRecord(2, "test note", _repository.GetAccountById(1020), _repository.GetAccountById(1100), 200),
                new BookingRecord(3, "test note", _repository.GetAccountById(1500), _repository.GetAccountById(2000), 140)
            };
        }

        public void SeedUsers()
        {
            List<User> users = new()
            {
                new User(1, "user1", HashPassword("testuserpass"), new NewUserRoleState()),
                new User(2, "user2", HashPassword("testuserpass"), new NewUserRoleState()),
                new User(3, "user3", HashPassword("testuserpass"), new NewUserRoleState())
            };

            foreach (User user in users)
            {
                _repository.AddUser(user);
            }
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
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

        public static Account CreateAccount(KeyValuePair<int, string> accountKvp, IDataRepository repo)
        {
            char firstIdDigit = accountKvp.Key.ToString()[0];
            // define account type by Id
            // TODO: The logic here has to be redone.
            // Defining the account type for income statement accounts does not work correctly yet.
            return firstIdDigit switch
            {
                // This is just the pattern matching equivalent of a switch.
                '1' => new ActiveAccount(accountKvp.Key, accountKvp.Value) { DataRepository = repo },
                '2' => new PassiveAccount(accountKvp.Key, accountKvp.Value) { DataRepository = repo },
                '3' => new IncomeAccount(accountKvp.Key, accountKvp.Value) { DataRepository = repo },
                '4' or '5' or '6' or '7' or '8' or '9' => new ExpenseAccount(accountKvp.Key, accountKvp.Value) { DataRepository = repo },
                _ => throw new Exception("Could not assign account to right account type. Account Id was: " + accountKvp.Key),
            };
        }
    }
}
