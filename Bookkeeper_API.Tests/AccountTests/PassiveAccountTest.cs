using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests.AccountTests
{
    public class PassiveAccountTest
    {
        [Fact(Skip = "not implemented")]
        public void TestCalculateBalance()
        {
            // Arrange
            PassiveAccount passiveAccount = new(1020, "Bank", new TestDataRepository());

            // Act
            decimal balance = passiveAccount.CalculateBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact(Skip = "not implemented")]
        public void TestDoDebitBooking()
        {
            // Arrange
            PassiveAccount passiveAccount = new(1020, "Bank", new TestDataRepository());
            const decimal debitAmount = 100;

            // Act
            passiveAccount.DoDebitBooking(debitAmount);

            // Assert
            Assert.Equal(-debitAmount, passiveAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoCreditBooking()
        {
            // Arrange
            PassiveAccount passiveAccount = new(1020, "Bank", new TestDataRepository());
            const decimal creditAmount = 100;

            // Act
            passiveAccount.DoCreditBooking(creditAmount);

            // Assert
            Assert.Equal(creditAmount, passiveAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoMultipleBookings()
        {
            // Arrange
            PassiveAccount passiveAccount = new(1020, "Bank", new TestDataRepository());
            const decimal creditAmount = 100;
            const decimal debitAmount = 50;

            // Act
            passiveAccount.DoCreditBooking(creditAmount);
            passiveAccount.DoDebitBooking(debitAmount);

            // Assert
            Assert.Equal(50, passiveAccount.CalculateBalance());
        }
    }
}