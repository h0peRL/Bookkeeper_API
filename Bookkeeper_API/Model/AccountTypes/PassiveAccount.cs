﻿namespace Bookkeeper_API.Model.AccountTypes
{
    public class PassiveAccount : Account
    {
        public PassiveAccount(int id, string accountName)
            : base(id, accountName)
        {
        }

        public override decimal CalculateBalance()
        {
            decimal balance = 0;
            var bookings = DataRepository.FindBookingRecordsForAccount(Id);

            foreach (var booking in bookings)
            {
                // check for booking type and conduct simulation
                if (booking.DebitAccount.Id == Id)
                {
                    balance -= booking.Amount;
                }
                else if (booking.CreditAccount.Id == Id)
                {
                    balance += booking.Amount;
                }
                else
                {
                    throw new Exception("This account has not relate to this booking record." +
                        "Something is wrong with your data repository.");
                }
            }

            return balance;
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
