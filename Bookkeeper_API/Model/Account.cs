namespace Bookkeeper_API.Model
{
    public abstract class Account
    {
        protected Account(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// The Entity Framework requires an empty constructor. Please do not remove it.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Account()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public decimal CalculateBalance()
        {
            throw new NotImplementedException();
        }

        public abstract void DoDebitBooking();

        public abstract void DoCreditBooking();
    }
}
