namespace Bookkeeper_API.Data.DTOs
{
    public class BalanceSheetDto
    {
        required public Dictionary<Dictionary<int, string>, decimal> Accounts { get; set; }

        required public decimal Total { get; set; }

        required public int Date { get; set; }
    }
}
