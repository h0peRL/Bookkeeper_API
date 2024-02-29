using Bookkeeper_API.Model;

namespace Bookkeeper_API.Data
{
    // Note:
    // The use of this interface was recommended by Daniel Lauk.
    // He is the teacher responsible for the course we are doing this project for.

    /// <summary>
    /// The data repository interface allows for a dependency injection of stub data when running unit tests.
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// Select all booking records related to an account.
        /// </summary>
        /// <param name="accountId">The ID of the account you'd like to look for in the records.</param>
        /// <returns>Collection of booking record objects.</returns>
        IEnumerable<BookingRecord> FindBookingRecordsForAccount(int accountId);
    }
}
