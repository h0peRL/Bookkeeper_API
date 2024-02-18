using Bookkeeper_API.Data.DTOs;

namespace Bookkeeper_API.Model
{
    public class BalanceSheet
    {
        private List<Account> _accounts;
        private decimal _total;
        private int _date;

        public BalanceSheet()
        {
            _accounts = GetAccounts();
            _total = GetTotal();

            // set today's date as timestamp
            throw new NotImplementedException();
        }

        public List<Account> Accounts
        {
            get { return _accounts; }
        }

        public decimal Total
        {
            get { return _total; }
        }

        public int Date
        {
            get { return _date; }
        }

        /// <summary>
        /// Calculates the current state of the balance and returns it in the shape of a DTO.
        /// </summary>
        /// <returns>Returns the JSON serializable DTO of the balance sheet.</returns>
        public BalanceSheetDto StateBalance()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all the accounts from the DB that belong to the balance sheet.
        /// </summary>
        /// <returns>Returns a list of all the balance sheet accounts.</returns>
        private List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the total amount of money that is in the company at given time.
        /// </summary>
        /// <returns>A decimal sum of all the account totals.</returns>
        private decimal GetTotal()
        {
            throw new NotImplementedException();
        }
    }
}
