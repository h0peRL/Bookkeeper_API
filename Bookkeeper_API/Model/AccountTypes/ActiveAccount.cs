namespace Bookkeeper_API.Model.AccountTypes
{
    public class ActiveAccount : Account
    {
        public ActiveAccount(int id, string name)
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
