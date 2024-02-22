using Bookkeeper_API.Model.AccountTypes;

namespace Bookkeeper_API.Tests
{
    public class ActiveAccountTest
    {
        [Fact(Skip = "not implemented")]
        public void TestCalculateBalance()
        {
            // Arrange
            ActiveAccount activeAccount = new ActiveAccount(1020, "Bank");

            // Act
            decimal balance = activeAccount.CalculateBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact(Skip = "not implemented")]
        public void TestDoDebitBooking()
        {
            // Arrange
            ActiveAccount activeAccount = new ActiveAccount(1020, "Bank");
            const decimal debitAmount = 100;

            // Act
            activeAccount.DoDebitBooking(debitAmount);

            // Assert
            Assert.Equal(debitAmount, activeAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoCreditBooking()
        {
            // Arrange
            ActiveAccount activeAccount = new ActiveAccount(1020, "Bank");
            const decimal creditAmount = 100;

            // Act
            activeAccount.DoCreditBooking(creditAmount);

            // Assert
            Assert.Equal(-creditAmount, activeAccount.CalculateBalance());
        }
    }
}
