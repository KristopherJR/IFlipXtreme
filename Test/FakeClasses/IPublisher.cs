//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle

/// <summary>
/// IPublisher interface. Implemented by classes that publisher events.
/// </summary>
namespace Test
{
    public interface IPublisher
    {
        /// <summary>
        /// Adds an ISubscriber to the IPublishers subscriber List.
        /// </summary>
        /// <param name="pSubscriber">The ISubscriber</param>
        void Subscribe(ISubscriber pSubscriber);

        /// <summary>
        /// Removes an ISubscriber from the IPublishers subscriber List.
        /// </summary>
        /// <param name="pSubscriber">The ISubscriber</param>
        void Unsubscribe(ISubscriber pSubscriber);
    }
}