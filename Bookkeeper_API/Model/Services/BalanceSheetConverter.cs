using Bookkeeper_API.Data.DTOs;

namespace Bookkeeper_API.Model.Services
{
    public class BalanceSheetConverter
    {
        public static BalanceSheetDto BalanceSheetToBalanceSheetDto(BalanceSheet balanceSheet)
        {
            Dictionary<(int, string), decimal> accountDictionary = new Dictionary<(int, string), decimal>();

            foreach (Account account in balanceSheet.Accounts)
            {
                accountDictionary.Add((account.Id, account.AccountName), account.CalculateBalance());
            }

            return new BalanceSheetDto()
            {
                Accounts = accountDictionary,
                Total = balanceSheet.Total,
                Date = balanceSheet.Date
            };
        }
    }
}
