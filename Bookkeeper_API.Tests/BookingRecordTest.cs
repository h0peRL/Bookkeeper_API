using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests
{
    public class BookingRecordTest
    {
        private readonly TestDataRepository _repository;

        public BookingRecordTest()
        {
            // Setup
            _repository = new TestDataRepository();
            _repository.SeedAccounts();
        }

        public void TestExecute()
        {
            // Arrange
            const string bookingNote = "Test";
            const decimal amount = 100;

            Account debitAccount = _repository.GetAccountById(1020); // Bank
            Account creditAccount = _repository.GetAccountById(2000); // VLL

            BookingRecord bookingRecord = new(null, bookingNote, debitAccount, creditAccount, amount);

            // Act
            // add 100 to debit account, so it won't get negative balance
            // TODO: Deal with this as it might cause an issue. Unit tests should be isolated and independent of other ressources.
            creditAccount.DoDebitBooking(100);

            bookingRecord.Execute();

            // Assert
            Assert.Equal(100, debitAccount.CalculateBalance());
            Assert.Equal(0, creditAccount.CalculateBalance());
        }

        public void TestDate()
        {
            // Arrange
            const string bookingNote = "Test";
            const decimal amount = 100;

            Account debitAccount = _repository.GetAccountById(1020); // Bank
            Account creditAccount = _repository.GetAccountById(2000); // VLL

            int nowTimestamp = (int)new DateTimeOffset(DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();

            // Act
            BookingRecord bookingRecord = new(null, bookingNote, debitAccount, creditAccount, amount);
            int bookingTimestamp = bookingRecord.BookingDate;

            // Assert
            Assert.True((bookingTimestamp - nowTimestamp) < 2); // 2s of tolerance
            Assert.True((bookingTimestamp - nowTimestamp) < -2); // 2s of tolerance
        }

        public void TestBookingNote()
        {
            // Arrange
            const string expectedNote = "Test";
            const decimal amount = 100;

            Account debitAccount = _repository.GetAccountById(1020); // Bank
            Account creditAccount = _repository.GetAccountById(2000); // VLL

            // Act
            BookingRecord bookingRecord = new(null, expectedNote, debitAccount, creditAccount, amount);
            string? actualNote = bookingRecord.BookingNote;

            // Assert
            Assert.NotNull(actualNote);
            Assert.Equal(expectedNote, actualNote);
        }
    }
}
