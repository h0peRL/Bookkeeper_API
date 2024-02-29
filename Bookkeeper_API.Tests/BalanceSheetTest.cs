using Bookkeeper_API.Data.DTOs;

namespace Bookkeeper_API.Tests
{
    public class BalanceSheetTest
    {
        [Fact(Skip = "not implemented")]
        public void TestStateBalanceAccounts()
        {
            // Arrange
            BalanceSheet balanceSheet = new();
            BalanceSheetDto mockBalanceSheet = CreateMockBalanceSheet();

            // Act
            BalanceSheetDto actualBalanceSheet = balanceSheet.StateBalance();

            // Assert
            Assert.Equal(mockBalanceSheet.Accounts, actualBalanceSheet.Accounts);
        }

        [Fact(Skip = "not implemented")]
        public void TestStateBalanceTotal()
        {
            // Arrange
            BalanceSheet balanceSheet = new();
            BalanceSheetDto mockBalanceSheet = CreateMockBalanceSheet();

            // Act
            BalanceSheetDto actualBalanceSheet = balanceSheet.StateBalance();

            // Assert
            Assert.Equal(mockBalanceSheet.Total, actualBalanceSheet.Total);
        }

        [Fact(Skip = "not implemented")]
        public void TestStateBalanceDate()
        {
            // Arrange
            BalanceSheet balanceSheet = new();
            BalanceSheetDto mockBalanceSheet = CreateMockBalanceSheet();

            // Act
            BalanceSheetDto actualBalanceSheet = balanceSheet.StateBalance();

            // Assert
            Assert.InRange(actualBalanceSheet.Date, mockBalanceSheet.Date - 1, mockBalanceSheet.Date + 1);
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
