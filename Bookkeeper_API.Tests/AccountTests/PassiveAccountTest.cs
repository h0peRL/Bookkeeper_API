using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests.AccountTests
{
    public class PassiveAccountTest
    {
        private readonly TestDataRepository _repository;

        public PassiveAccountTest()
        {
            // Setup
            _repository = new TestDataRepository();
            _repository.SeedAccounts();
        }

        [Fact]
        public void TestCalculateBalance()
        {
            // Arrange
            Account account = _repository.GetAccountById(2000);

            // Act
            if (account.GetType() != typeof(PassiveAccount))
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
            PassiveAccount passiveAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
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
            PassiveAccount passiveAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
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
            PassiveAccount passiveAccount = new(1020, "Bank")
            {
                DataRepository = new TestDataRepository()
            };
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