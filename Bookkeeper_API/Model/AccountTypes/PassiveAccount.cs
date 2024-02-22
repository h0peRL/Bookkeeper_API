namespace Bookkeeper_API.Model.AccountTypes
{
    public class PassiveAccount : Account
    {
        public PassiveAccount(int id, string name)
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
