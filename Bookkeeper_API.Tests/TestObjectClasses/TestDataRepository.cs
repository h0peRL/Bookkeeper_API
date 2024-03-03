using Bookkeeper_API.Data;

namespace Bookkeeper_API.Tests.TestObjectClasses
{
    internal class TestDataRepository : IDataRepository
    {
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
