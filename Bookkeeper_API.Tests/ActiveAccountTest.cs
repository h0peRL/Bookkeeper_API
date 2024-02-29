using Bookkeeper_API.Model.AccountTypes;
using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests
{
    public class ActiveAccountTest
    {
        [Fact(Skip = "not implemented")]
        public void TestCalculateBalance()
        {
            // Arrange
            ActiveAccount activeAccount = new(1020, "Bank", new TestDataRepository());

            // Act
            decimal balance = activeAccount.CalculateBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact(Skip = "not implemented")]
        public void TestDoDebitBooking()
        {
            // Arrange
            ActiveAccount activeAccount = new(1020, "Bank", new TestDataRepository());
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
            ActiveAccount activeAccount = new(1020, "Bank", new TestDataRepository());
            const decimal creditAmount = 100;

            // Act
            activeAccount.DoCreditBooking(creditAmount);

            // Assert
            Assert.Equal(-creditAmount, activeAccount.CalculateBalance());
        }

        [Fact(Skip = "not implemented")]
        public void TestDoMultipleBookings()
        {
            // Arrange
            ActiveAccount activeAccount = new(1020, "Bank", new TestDataRepository());
            const decimal debitAmount = 100;
            const decimal creditAmount = 50;

            // Act
            activeAccount.DoDebitBooking(debitAmount);
            activeAccount.DoCreditBooking(creditAmount);

            // Assert
            Assert.Equal(50, activeAccount.CalculateBalance());
        }
    }
}
