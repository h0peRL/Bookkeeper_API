using Bookkeeper_API.Model.AccountTypes;

namespace Bookkeeper_API.Tests
{
    public class IncomeAccountTest
    {
        [Fact(Skip = "not implemented")]
        public void TestCalculateBalance()
        {
            // Arrange
            IncomeAccount incomeAccount = new(1020, "Bank");

            // Act
            decimal balance = incomeAccount.CalculateBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact(Skip = "not implemented")]
        public void TestDoDebitBooking()
        {
            // Arrange
            IncomeAccount incomeAccount = new(1020, "Bank");
            const decimal debitAmount = 100;

            // Act
            incomeAccount.DoDebitBooking(debitAmount);

            // Assert
            Assert.Equal(-debitAmount, incomeAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoCreditBooking()
        {
            // Arrange
            IncomeAccount incomeAccount = new(1020, "Bank");
            const decimal creditAmount = 100;

            // Act
            incomeAccount.DoCreditBooking(creditAmount);

            // Assert
            Assert.Equal(creditAmount, incomeAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoMultipleBookings()
        {
            // Arrange
            IncomeAccount incomeAccount = new(1020, "Bank");
            const decimal creditAmount = 100;
            const decimal debitAmount = 50;

            // Act
            incomeAccount.DoCreditBooking(creditAmount);
            incomeAccount.DoDebitBooking(debitAmount);

            // Assert
            Assert.Equal(50, incomeAccount.CalculateBalance());
        }
    }
}
