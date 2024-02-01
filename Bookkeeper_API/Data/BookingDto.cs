namespace Bookkeeper_API.Data
{
    public class BookingDto
    {
        public string? BookingNote { get; set; }

        required public int DebitAccount { get; set; }

        required public int CreditAccount { get; set; }

        required public decimal Amount { get; set; }
    }
}
