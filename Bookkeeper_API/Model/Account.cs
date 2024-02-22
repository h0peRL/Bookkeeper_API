namespace Bookkeeper_API.Model
{
    public abstract class Account
    {
        private readonly int _id;
        private readonly string _name;

        protected Account(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public decimal CalculateBalance()
        {
            throw new NotImplementedException();
        }

        public abstract void DoDebitBooking();

        public abstract void DoCreditBooking();
    }
}
