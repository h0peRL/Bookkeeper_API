using Bookkeeper_API.Model.AccountTypes;

namespace Bookkeeper_API.Tests
{
    public class PassiveAccountTest
    {
        [Fact(Skip = "not implemented")]
        public void TestCalculateBalance()
        {
            // Arrange
            PassiveAccount passiveAccount = new PassiveAccount(1020, "Bank");

            // Act
            decimal balance = passiveAccount.CalculateBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact(Skip = "not implemented")]
        public void TestDoDebitBooking()
        {
            // Arrange
            PassiveAccount passiveAccount = new PassiveAccount(1020, "Bank");
            const decimal debitAmount = 100;

            // Act
            passiveAccount.DoDebitBooking(debitAmount);

            // Assert
            Assert.Equal(debitAmount, passiveAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoCreditBooking()
        {
            // Arrange
            PassiveAccount passiveAccount = new PassiveAccount(1020, "Bank");
            const decimal creditAmount = 100;

            // Act
            passiveAccount.DoCreditBooking(creditAmount);

            // Assert
            Assert.Equal(-creditAmount, passiveAccount.CalculateBalance());
        }
    }
}