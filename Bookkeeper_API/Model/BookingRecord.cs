namespace Bookkeeper_API.Model
{
    public class BookingRecord
    {
        private readonly int _id;
        private string? _bookingNote;
        private int _bookingDate;
        private Account _debitAccount;
        private Account _creditAccount;
        private decimal _amount;

        public BookingRecord(int? id, string? bookingNote, Account creditAccount, Account debitAccount, decimal amount)
        {
            _id = id;
            _bookingNote = bookingNote;
            _creditAccount = creditAccount;
            _debitAccount = debitAccount;
            _amount = amount;

            // set today's date as timestamp
            throw new NotImplementedException();
        }

        public int? Id
        {
            get { return _id; }
        }

        public string? BookingNote
        {
            get { return _bookingNote; }
        }

        public Account DebitAccount
        {
            get { return _debitAccount; }
        }

        public Account CreditAccount
        {
            get { return _creditAccount; }
        }

        public decimal Amount
        {
            get { return _amount; }
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
