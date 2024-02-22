namespace Bookkeeper_API.Model.AccountTypes
{
    public class ExpenseAccount : Account
    {
        public ExpenseAccount(int id, string name)
            : base(id, name)
        {
        }

        public override decimal CalculateBalance()
        {
            throw new NotImplementedException();
        }

        public override void DoDebitBooking(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void DoCreditBooking(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
