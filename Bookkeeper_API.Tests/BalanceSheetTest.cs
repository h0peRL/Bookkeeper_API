using Bookkeeper_API.Data.DTOs;
using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests
{
    public class BalanceSheetTest
    {
        private readonly TestDataRepository _repository;

        public BalanceSheetTest()
        {
            // Setup
            _repository = new TestDataRepository();
            _repository.SeedAccounts();
        }

        [Fact]
        public void TestAccounts()
        {
            // Arrange
            BalanceSheet balanceSheet = new(_repository);
            List<Account> expectedAccounts = _repository.GetBalanceSheetAccounts().ToList();

            // Act
            List<Account> actualAccounts = balanceSheet.Accounts;

            // Assert
            Assert.Equal(expectedAccounts, actualAccounts);
        }

        [Fact]
        public void TestTotal()
        {
            // Arrange
            decimal expectedTotal = 400;

            // Create booking record to
            Account creditAccount = _repository.GetAccountById(2000); // VLL
            Account debitAccount = _repository.GetAccountById(1020); // Bank
            BookingRecord bookingRecord = new(null, null, creditAccount, debitAccount, expectedTotal);
            bookingRecord.Execute();

            // Act
            BalanceSheet balanceSheet = new(_repository); // Total gets calculated on init.
            decimal actualTotal = balanceSheet.Total;

            // Assert
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Fact]
        public void TestDate()
        {
            // Arrange
            int nowTimestamp = (int)new DateTimeOffset(DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();

            // Act
            BalanceSheet balanceSheet = new(_repository);
            int actualTimestamp = balanceSheet.Date;

            // Assert
            Assert.True((actualTimestamp - nowTimestamp) < 2); // 2s of tolerance
            Assert.True((actualTimestamp - nowTimestamp) > -2); // 2s of tolerance
        }

        private BalanceSheetDto CreateMockBalanceSheet()
        {
            BalanceSheetDto mockBalanceSheet = new()
            {
                Accounts = new Dictionary<(int, string), decimal>
                {
                    { (1020, "Bank"), 100 },
                    { (2000, "VLL"), 200 },
                    { (1100, "FLL"), 300 }
                },
                Total = 400,
                Date = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
            };
            return mockBalanceSheet;
        }
    }
}
