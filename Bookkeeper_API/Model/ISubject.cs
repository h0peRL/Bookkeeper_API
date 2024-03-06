namespace Bookkeeper_API.Model
{
    /// <summary>
    /// Interface for a simple subject of an observer, according to the observer pattern.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// The method observers of the according subject can use to subscribe to relevant events.
        /// </summary>
        /// <param name="observer">The observer passes a reference to itself so it can be added to a list.</param>
        void Subscribe(IObserver observer);

        /// <summary>
        /// The method observers of the according subject can use to unscubscribe from once relevant events.
        /// </summary>
        /// <param name="observer">The observer passes a reference to itself so it can be removed from list.</param>
        void Unsubscribe(IObserver observer);

        /// <summary>
        /// The method that should be used to notify observers of relevant events.
        /// </summary>
        void NotifyObservers();
    }
}
