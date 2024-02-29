using Bookkeeper_API.Model;

namespace Bookkeeper_API.Data
{
    public class EFCoreDataRepository : IDataRepository
    {
        private readonly AppDbContext _db;

        public EFCoreDataRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public IEnumerable<BookingRecord> FindBookingRecordsForAccount(int accountId)
        {
            return _db.Bookings.Where(b => b.DebitAccount.Id == accountId
            || b.CreditAccount.Id == accountId);
        }
    }
}
