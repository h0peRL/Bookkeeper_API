using Bookkeeper_API.Model;
using Bookkeeper_API.Model.UserManagement;

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
        // READ OPERATIONS

        /// <summary>
        /// Select all booking records related to an account.
        /// </summary>
        /// <param name="accountId">The ID of the account you'd like to look for in the records.</param>
        /// <returns>Collection of booking record objects.</returns>
        IEnumerable<BookingRecord> FindBookingRecordsForAccount(int accountId);

        /// <summary>
        /// Select an account by its Id.
        /// </summary>
        /// <param name="accountId">Id of the account you are looking for.</param>
        /// <returns>Account with the Id that has been passed as a parameter.</returns>
        Account GetAccountById(int accountId);

        /// <summary>
        /// Select all balance sheet accounts.
        /// </summary>
        /// <returns>Collection of active and passive accounts.</returns>
        IEnumerable<Account> GetBalanceSheetAccounts();

        /// <summary>
        /// Select all income statement accounts.
        /// </summary>
        /// <returns>Collection of income and expense accounts.</returns>
        IEnumerable<Account> GetIncomeStatementAccounts();

        /// <summary>
        /// Select a user by its Id.
        /// </summary>
        /// <param name="userId">Id of the user you are looking for.</param>
        /// <returns>User with the Id that has been passed as a parameter.</returns>
        User GetUserById(int userId);

        // INSERT OPERATIONS

        /// <summary>
        /// Insert a new account.
        /// </summary>
        /// <param name="account">Account to insert.</param>
        void AddAccount(Account account);

        /// <summary>
        /// Insert a new booking record.
        /// </summary>
        /// <param name="record">Record to insert.</param>
        void AddBookingRecord(BookingRecord record);

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">New user to be registered. (without an Id).</param>
        void AddUser(User user);

        // UPDATE OPERATIONS

        /// <summary>
        /// Authorizes newly registered users to use the system. Without this, the user won't be allowed to perform any operations.
        /// </summary>
        /// <param name="userId">Id of the user to be authorized for use.</param>
        void AuthorizeNewUser(int userId);

        /// <summary>
        /// Removes authorization from existing users.
        /// </summary>
        /// <param name="userId">Id of the user to be disapproved.</param>
        void DisapproveExistingUser(int userId);
    }
}
