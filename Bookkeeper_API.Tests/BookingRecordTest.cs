using Bookkeeper_API.Tests.TestObjectClasses;

namespace Bookkeeper_API.Tests
{
    public class BookingRecordTest
    {
        [Fact(Skip = "not implemented")]
        public void TestExecute()
        {
            // Arrange
            const int id = 1;
            const string bookingNote = "Test";
            Account debitAccount = new ActiveAccount(1020, "Bank", new TestDataRepository());
            Account creditAccount = new PassiveAccount(2000, "VLL", new TestDataRepository());
            const decimal amount = 100;

            BookingRecord bookingRecord = new BookingRecord(id, bookingNote, debitAccount, creditAccount, amount);

            // Act
            // add 100 to debit account, so it won't get negative balance
            creditAccount.DoDebitBooking(100);

            bookingRecord.Execute();

            // Assert
            Assert.Equal(100, debitAccount.CalculateBalance());
            Assert.Equal(0, creditAccount.CalculateBalance());
        }
    }
}
