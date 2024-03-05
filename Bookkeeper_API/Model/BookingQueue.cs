using System.Runtime.CompilerServices;

namespace Bookkeeper_API.Model
{
    /// <summary>
    /// This class is a singleton implementation of a regular <see cref="Queue{T}"/>.
    /// The point of it is to offer a FIFO-like data structure to process booking requests in an orderly manner.
    /// This way a conflict with impossible bookings can be avoided.
    /// </summary>
    public class BookingQueue : Queue<BookingRecord>
    {
        // To implement this class, the following sources have been used:
        // https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
        // Design Patterns, Elements of Reusable Object-Oriented Software by Erich Gamma et al.

        private static readonly object _lock = new();

        // Singleton instance that gets referenced, if it has been asked for.
        private static BookingQueue? _instance;

        // Constructor must be private, so only the class itself can use it.
        private BookingQueue()
        {
        }

        /// <summary>
        /// This method creates a Booking Queue instance, if it has not been instantiated yet.
        /// If there is an instance of it already, a reference to that one will be returned.
        /// </summary>
        /// <returns>Reference to a singleton instance.</returns>
        public static BookingQueue GetInstance()
        {
            if (_instance == null)
            {
                // This section can only be accessed by a single thread at a time,
                // thus, a conflict between threads creating the first instance at the
                // same time should be avoided.
                lock (_lock)
                {
                    _instance ??= new BookingQueue();
                }
            }

            return _instance;
        }
    }
}
