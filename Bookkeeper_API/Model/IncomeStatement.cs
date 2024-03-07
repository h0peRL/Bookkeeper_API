using Bookkeeper_API.Data;
using Bookkeeper_API.Data.DTOs;

namespace Bookkeeper_API.Model
{
    public class IncomeStatement
    {
        private List<Account> _accounts;
        private decimal _total;
        private int _date;
        private decimal _result;
        private bool _isLoss;
        private readonly IDataRepository _dataRepository;
        private List<Account> _incomeAccounts = new();
        private List<Account> _expenseAccounts = new();

        public IncomeStatement(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _accounts = GetAccounts();
            _total = GetTotal();
            _result = GetResult();
            _isLoss = CheckIfLoss();
            SplitIncomeStatementAccounts(_accounts);
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
            return new IncomeStatementDto
            {
                Accounts = _accounts.ToDictionary(account => (account.Id, account.AccountName), account => account.CalculateBalance()),
                Total = _total,
                Date = _date,
                Result = _result,
                IsLoss = _isLoss
            };
        }

        /// <summary>
        /// Get all the accounts from the DB that belong to the income statement.
        /// </summary>
        /// <returns>Returns a list of all the income statement accounts.</returns>
        private List<Account> GetAccounts()
        {
            IEnumerable<Account> accounts = _dataRepository.GetIncomeStatementAccounts();
            return accounts.ToList();
        }

        /// <summary>
        /// Calculates the total amount of money that appears in the company's income statement.
        /// </summary>
        /// <returns>Returns a decimal sum of all the account totals.</returns>
        private decimal GetTotal()
        {
            // calculate balance for income and expense accounts and see which one is greater. return the greater one.
            return _incomeAccounts.Sum(account => account.CalculateBalance()) + _expenseAccounts.Sum(account => account.CalculateBalance());
        }

        /// <summary>
        /// Calculates the result that the income statement would generate at given time.
        /// </summary>
        /// <returns>Returns a decimal with the result value.</returns>
        private decimal GetResult()
        {
            return _incomeAccounts.Sum(account => account.CalculateBalance()) - _expenseAccounts.Sum(account => account.CalculateBalance());
        }

        /// <summary>
        /// Checks if the result of the income statement is considered a loss or not.
        /// </summary>
        /// <returns>Returns true if it is a loss and false if it's additional income.</returns>
        private bool CheckIfLoss()
        {
            return _incomeAccounts.Sum(account => account.CalculateBalance()) <= _expenseAccounts.Sum(account => account.CalculateBalance());
        }

        private void SplitIncomeStatementAccounts(List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                switch (account.Id)
                {
                    case >= 3000 and <= 3999:
                        _incomeAccounts.Add(account);
                        break;
                    case >= 4000 and <= 4999:
                        _expenseAccounts.Add(account);
                        break;
                }
            }
        }

        private List<Account> GetIncomeAccounts()
        {
            return _accounts.Where(account => account.Id >= 3000 && account.Id <= 3999).ToList();
        }

        private List<Account> GetExpenseAccounts()
        {
            return _accounts.Where(account => account.Id >= 4000 && account.Id <= 4999).ToList();
        }
    }
}
