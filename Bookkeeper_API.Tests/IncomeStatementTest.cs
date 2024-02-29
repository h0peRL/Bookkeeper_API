using Bookkeeper_API.Data.DTOs;

namespace Bookkeeper_API.Tests
{
    public class IncomeStatementTest
    {
        [Fact(Skip = "not implemented")]
        public void TestStateIncomeAccounts()
        {
            // Arrange
            IncomeSatetement incomeStatement = new();
            IncomeStatementDto mockIncomeStatement = CreateMockIncomeStatement();

            // Act
            IncomeStatementDto actualIncomeStatement = incomeStatement.StateIncome();

            // Assert
            Assert.Equal(mockIncomeStatement.Accounts, actualIncomeStatement.Accounts);
        }

        [Fact(Skip = "not implemented")]
        public void TestStateIncomeTotal()
        {
            // Arrange
            IncomeSatetement incomeStatement = new();
            IncomeStatementDto mockIncomeStatement = CreateMockIncomeStatement();

            // Act
            IncomeStatementDto actualIncomeStatement = incomeStatement.StateIncome();

            // Assert
            Assert.Equal(mockIncomeStatement.Total, actualIncomeStatement.Total);
        }

        [Fact(Skip = "not implemented")]
        public void TestStateIncomeDate()
        {
            // Arrange
            IncomeSatetement incomeStatement = new();
            IncomeStatementDto mockIncomeStatement = CreateMockIncomeStatement();

            // Act
            IncomeStatementDto actualIncomeStatement = incomeStatement.StateIncome();

            // Assert
            Assert.Equal(mockIncomeStatement.Date, actualIncomeStatement.Date);
        }

        [Fact(Skip = "not implemented")]
        public void TestStateIncomeResult()
        {
            // Arrange
            IncomeSatetement incomeStatement = new();
            IncomeStatementDto mockIncomeStatement = CreateMockIncomeStatement();

            // Act
            IncomeStatementDto actualIncomeStatement = incomeStatement.StateIncome();

            // Assert
            Assert.Equal(mockIncomeStatement.Result, actualIncomeStatement.Result);
        }

        [Fact(Skip = "not implemented")]
        public void TestStateIncomeIsLoss()
        {
            // Arrange
            IncomeSatetement incomeStatement = new();
            IncomeStatementDto mockIncomeStatement = CreateMockIncomeStatement();

            // Act
            IncomeStatementDto actualIncomeStatement = incomeStatement.StateIncome();

            // Assert
            Assert.Equal(mockIncomeStatement.IsLoss, actualIncomeStatement.IsLoss);
        }

        private IncomeStatementDto CreateMockIncomeStatement()
        {
            IncomeStatementDto incomeStatement = new()
            {
                Accounts = new Dictionary<(int, string), decimal>
                {
                    { (1020, "Bank"), 100 },
                    { (2000, "VLL"), 200 },
                    { (1100, "FLL"), 300 }
                },
                Total = 400,
                Date = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                Result = 200,
                IsLoss = false
            };
            return incomeStatement;
        }
    }
}
