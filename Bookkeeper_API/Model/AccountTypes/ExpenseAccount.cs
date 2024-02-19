namespace Bookkeeper_API.Model.AccountTypes
{
    public class ExpenseAccount : Account
    {
        public ExpenseAccount(int id, string name)
            : base(id, name)
        {
        }

        public override void DoDebitBooking()
        {
            throw new NotImplementedException();
        }

        public override void DoCreditBooking()
        {
            throw new NotImplementedException();
        }
    }
}
