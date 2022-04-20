//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle

namespace Library
{
    /// <summary>
    /// IPublisher Interface
    /// </summary>
    public interface IPublisher
    {
        /// <summary>
        /// Subscribe Method:  Adds an ISubscriber to the list of subscribers.
        /// </summary>
        /// <param name="pSubscriber">The ISubscriber object to be subscribed</param>
        void Subscribe(ISubscriber pSubscriber);

        /// <summary>
        /// Unsubscribe Method:  Removes an ISubscriber from the list of subscribers.
        /// </summary>
        /// <param name="pSubscriber">The ISubscriber object to be unsubscribed</param>
        void Unsubscribe(ISubscriber pSubscriber);
    }
}