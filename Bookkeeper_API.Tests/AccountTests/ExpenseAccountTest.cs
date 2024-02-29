using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests.AccountTests
{
    public class ExpenseAccountTest
    {
        [Fact(Skip = "not implemented")]
        public void TestCalculateBalance()
        {
            // Arrange
            ExpenseAccount expenseAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };

            // Act
            decimal balance = expenseAccount.CalculateBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact(Skip = "not implemented")]
        public void TestDoDebitBooking()
        {
            // Arrange
            ExpenseAccount expenseAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
            const decimal debitAmount = 100;

            // Act
            expenseAccount.DoDebitBooking(debitAmount);

            // Assert
            Assert.Equal(debitAmount, expenseAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoCreditBooking()
        {
            // Arrange
            ExpenseAccount expenseAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
            const decimal creditAmount = 100;

            // Act
            expenseAccount.DoCreditBooking(creditAmount);

            // Assert
            Assert.Equal(-creditAmount, expenseAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoMultipleBookings()
        {
            // Arrange
            ExpenseAccount expenseAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
            const decimal debitAmount = 100;
            const decimal creditAmount = 50;

            // Act
            expenseAccount.DoDebitBooking(debitAmount);
            expenseAccount.DoCreditBooking(creditAmount);

            // Assert
            Assert.Equal(50, expenseAccount.CalculateBalance());
        }
    }
}