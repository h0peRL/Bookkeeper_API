using Bookkeeper_API.Data.DTOs;

namespace Bookkeeper_API.Model
{
    public class IncomeSatetement
    {
        private List<Account> _accounts;
        private decimal _total;
        private int _date;
        private decimal _result;
        private bool _isLoss;

        public IncomeSatetement()
        {
            _accounts = GetAccounts();
            _total = GetTotal();
            _result = GetResult();
            _isLoss = CheckIfLoss();
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

        public decimal Result
        {
            get { return _result; }
        }

        public bool IsLoss
        {
            get { return _isLoss; }
        }

        /// <summary>
        /// Calculates the current state of the balance and returns it in the shape of a DTO.
        /// </summary>
        /// <returns>Returns the JSON serializable DTO of the income statement.</returns>
        public IncomeStatementDto StateIncome()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all the accounts from the DB that belong to the income statement.
        /// </summary>
        /// <returns>Returns a list of all the income statement accounts.</returns>
        private List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the total amount of money that appears in the company's income statement.
        /// </summary>
        /// <returns>Returns a decimal sum of all the account totals.</returns>
        private decimal GetTotal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the result that the income statement would generate at given time.
        /// </summary>
        /// <returns>Returns a decimal with the result value.</returns>
        private decimal GetResult()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the result of the income statement is considered a loss or not.
        /// </summary>
        /// <returns>Returns true if it is a loss and false if it's additional income.</returns>
        private bool CheckIfLoss()
        {
            throw new NotImplementedException();
        }
    }
}
