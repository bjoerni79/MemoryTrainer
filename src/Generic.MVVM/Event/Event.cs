using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.MVVM.Event
{
    /// <summary>
    /// Implements an IEvent
    /// </summary>
    /// <seealso cref="IEvent"/>
    public class Event : IEvent
    {
        private List<IEventListener> listenerCollection;


        /// <summary>
        /// Creates a new event with serial triggering
        /// </summary>
        /// <param name="eventId">the id</param>
        public Event(string eventId) 
        {
            EventId = eventId;
            listenerCollection = new List<IEventListener>();
        }

        /// <summary>
        /// Returns the event id
        /// </summary>
        public string EventId { get; private set; }

        /// <summary>
        /// Adds a new listener to the event
        /// </summary>
        /// <param name="listener">the listener</param>
        public void AddListener(IEventListener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            listenerCollection.Add(listener);
        }

        /// <summary>
        /// Removes a listener from the event
        /// </summary>
        /// <param name="listener">the listener</param>
        public void RemoveListener(IEventListener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            listenerCollection.Remove(listener);
        }

        /// <summary>
        /// Removes all listener
        /// </summary>
        public void Clear()
        {
            listenerCollection = new List<IEventListener>();
        }

        /// <summary>
        /// Triggers the event asynchronously and waits for all pending tasks
        /// </summary>
        /// <returns>A task reference</returns>
        public async Task TriggerAsync()
        {
            var tasks = new List<Task>();

            foreach (var listener in listenerCollection)
            {
                var updateTask = Task.Run(() => listener.OnTrigger(EventId));
                tasks.Add(updateTask);
            }

            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Triggers the event synchronously
        /// </summary>
        /// <seealso cref="IEvent.Trigger"/>
        public void Trigger()
        {
            foreach (var listener in listenerCollection)
            {
                try
                {
                    listener.OnTrigger(EventId);
                }
                catch (Exception ex)
                {
                    throw new EventTriggerException(EventId, "Exception occured during trigger", ex);
                }


            }
        }
    }
}
