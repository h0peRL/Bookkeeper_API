using Bookkeeper_API.Data.DTOs;
using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests
{
    public class IncomeStatementTest
    {
        private readonly TestDataRepository _repository;

        public IncomeStatementTest()
        {
            // Setup
            _repository = new TestDataRepository();
            _repository.SeedAccounts();
        }

        [Fact(Skip = "not implemented")]
        public void TestAccounts()
        {
            // Arrange
            IncomeStatement incomeStatement = new(_repository);
            List<Account> expectedAccounts = _repository.GetIncomeStatementAccounts().ToList();

            // Act
            List<Account> actualAccounts = incomeStatement.Accounts;

            // Assert
            Assert.Equal(expectedAccounts, actualAccounts);
        }

        [Fact(Skip = "not implemented")]
        public void TestStateIncomeTotal()
        {
            // Arrange
            IncomeStatement incomeStatement = new(_repository);
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
            IncomeStatement incomeStatement = new(_repository);
            IncomeStatementDto mockIncomeStatement = CreateMockIncomeStatement();

            // Act
            IncomeStatementDto actualIncomeStatement = incomeStatement.StateIncome();

            // Assert
            Assert.InRange(actualIncomeStatement.Date, mockIncomeStatement.Date - 1, mockIncomeStatement.Date + 1);
        }

        [Fact(Skip = "not implemented")]
        public void TestStateIncomeResult()
        {
            // Arrange
            IncomeStatement incomeStatement = new(_repository);
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
            IncomeStatement incomeStatement = new(_repository);
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
                    { (4200, "Cost of materials (trade)"), 200 },
                    { (3200, "Revenues from sales of goods (trade)"), 400 }
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
