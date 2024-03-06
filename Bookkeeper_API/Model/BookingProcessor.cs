namespace Bookkeeper_API.Model
{
    public class BookingProcessor : IObserver
    {
        public void Update()
        {
            // In this case our subject is expected to be a booking queue.
            // The booking queue is a singleton, so we do not need a reference to it passed through the params.
            BookingQueue queue = BookingQueue.GetInstance();

            // The overridden queue is set up to notify us through Update() when a new booking record gets enqueued.
            // Once we get a notification, this processor should start dequeueing booking requests as long as there is a queue.
            while (queue.Count > 0)
            {
                BookingRecord bookingRecord = queue.Dequeue();
                try
                {
                    bookingRecord.Execute();
                }
                catch (Exception)
                {
                    throw;
                    // TODO: Notify the endpoint that there was an issue processing the booking request.
                }
            }

            // TODO: Notify the endpoint that the booking request could be processed successfully.
        }
    }
}
