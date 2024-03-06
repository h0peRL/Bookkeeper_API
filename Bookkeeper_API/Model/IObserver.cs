namespace Bookkeeper_API.Model
{
    /// <summary>
    /// Interface for a simple observer of a subject, according to the observer pattern.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// This method gets called by the the subjects that have been subscribed to if there have been any relevant changes.
        /// </summary>
        void Update();
    }
}
