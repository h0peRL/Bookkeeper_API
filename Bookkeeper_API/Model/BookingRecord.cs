using Bookkeeper_API.Data;

namespace Bookkeeper_API.Model
{
    public class BookingRecord
    {
        public BookingRecord(int? id, string? bookingNote, Account creditAccount, Account debitAccount, decimal amount)
        {
            Id = id;
            BookingNote = bookingNote;
            DebitAccount = debitAccount;
            CreditAccount = creditAccount;
            Amount = amount;
            BookingDate = 1000; // TODO: set current timestamp
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingRecord"/> class.
        /// The Entity Framework requires an empty constructor. Please do not remove it.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private BookingRecord()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int? Id { get; private set; }

        public string? BookingNote { get; private set; }

        public Account DebitAccount { get; private set; }

        public Account CreditAccount { get; private set; }

        public decimal Amount { get; private set; }

        public int BookingDate { get; private set; }

        public void Execute()
        {
            // make sure data source is matching
            if (!ReferenceEquals(DebitAccount.DataRepository, CreditAccount.DataRepository))
            {
                throw new Exception("Data repository pointers of the accounts do not match!" +
                    "Make sure you're using the same data repo instance on both accounts.");
            }

            IDataRepository repo = DebitAccount.DataRepository;

            repo.AddBookingRecord(this);
        }
    }
}
