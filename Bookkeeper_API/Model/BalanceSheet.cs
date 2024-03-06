using Bookkeeper_API.Data;
using Bookkeeper_API.Data.DTOs;
using Bookkeeper_API.Model.Services;

namespace Bookkeeper_API.Model
{
    public class BalanceSheet
    {
        private List<Account> _accounts;
        private decimal _total;
        private int _date;
        private IDataRepository _repository;

        public BalanceSheet(IDataRepository repository)
        {
            _accounts = GetAccounts();
            _total = GetTotal();
            _date = UnixTimestampConverter.DateTimeToUnixTimestamp(DateTime.Now);
            _repository = repository;
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
            BalanceSheetDto dto = BalanceSheetConverter.BalanceSheetToBalanceSheetDto(this);
            return dto;
        }

        /// <summary>
        /// Get all the accounts from the DB that belong to the balance sheet.
        /// </summary>
        /// <returns>Returns a list of all the balance sheet accounts.</returns>
        private List<Account> GetAccounts()
        {
            IEnumerable<Account> accounts = _repository.GetBalanceSheetAccounts();
            return accounts.ToList();
        }

        /// <summary>
        /// Calculates the total amount of money that is in the company at given time.
        /// </summary>
        /// <returns>A decimal sum of all the account totals.</returns>
        private decimal GetTotal()
        {
            decimal total = 0;
            foreach (Account account in _accounts)
            {
                total += account.CalculateBalance();
            }

            return total;
        }
    }
}
