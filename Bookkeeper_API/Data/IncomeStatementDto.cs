﻿namespace Bookkeeper_API.Data
{
    public class IncomeStatementDto
    {
        required public Dictionary<Dictionary<int, string>, decimal> Accounts { get; set; }

        required public decimal Total { get; set; }

        required public int Date { get; set; }

        required public decimal Result { get; set; }

        required public bool IsLoss { get; set; }
    }
}
