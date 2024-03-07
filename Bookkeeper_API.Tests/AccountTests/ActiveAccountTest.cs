using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests.AccountTests
{
    public class ActiveAccountTest
    {
        private readonly TestDataRepository _repository;

        public ActiveAccountTest()
        {
            // Setup
            _repository = new TestDataRepository();
            _repository.SeedAccounts();
        }

        [Fact]
        public void TestCalculateBalance()
        {
            // Arrange
            Account account = _repository.GetAccountById(1020);

            // Act
            if (account.GetType() != typeof(ActiveAccount))
            {
                throw new Exception("The received account is not of the right type.");
            }

            decimal balance = account.CalculateBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact(Skip = "not implemented")]
        public void TestDoDebitBooking()
        {
            // Arrange
            ActiveAccount activeAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
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
            ActiveAccount activeAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
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
            ActiveAccount activeAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
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
