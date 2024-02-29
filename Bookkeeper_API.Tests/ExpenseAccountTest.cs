using Bookkeeper_API.Model.AccountTypes;

namespace Bookkeeper_API.Tests
{
    public class ExpenseAccountTest
    {
        [Fact(Skip = "not implemented")]
        public void TestCalculateBalance()
        {
            // Arrange
            ExpenseAccount expenseAccount = new(1020, "Bank");

            // Act
            decimal balance = expenseAccount.CalculateBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact(Skip = "not implemented")]
        public void TestDoDebitBooking()
        {
            // Arrange
            ExpenseAccount expenseAccount = new(1020, "Bank");
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
            ExpenseAccount expenseAccount = new(1020, "Bank");
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
            ExpenseAccount expenseAccount = new(1020, "Bank");
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