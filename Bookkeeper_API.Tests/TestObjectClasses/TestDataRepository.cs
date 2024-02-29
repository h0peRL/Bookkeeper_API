using Bookkeeper_API.Data;

namespace Bookkeeper_API.Tests.TestObjectClasses
{
    internal class TestDataRepository : IDataRepository
    {
        public IEnumerable<BookingRecord> FindBookingRecordsForAccount(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
