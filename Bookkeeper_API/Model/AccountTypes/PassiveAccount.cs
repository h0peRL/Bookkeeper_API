namespace Bookkeeper_API.Model.AccountTypes
{
    public class PassiveAccount : Account
    {
        public PassiveAccount(int id, string accountName)
            : base(id, accountName)
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
