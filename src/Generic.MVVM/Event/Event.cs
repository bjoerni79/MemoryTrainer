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
        private EventTriggerMode mode;

        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="eventId">the id</param>
        /// <param name="mode">the mode</param>
        public Event(string eventId, EventTriggerMode mode)
        {
            EventId = eventId;
            this.mode = mode;
            listenerCollection = new List<IEventListener>();
        }

        /// <summary>
        /// Creates a new event with serial triggering
        /// </summary>
        /// <param name="eventId">the id</param>
        public Event(string eventId) : this(eventId, EventTriggerMode.Serial)
        {
            // empty
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

        ///// <summary>
        ///// Triggers the event ... TODO!
        ///// </summary>
        ///// <returns></returns>
        //public async Task TriggerAsync()
        //{

        //    /*
        //     * Todo:
        //     * 
        //     * Wie implementiert man eine Task Umgebung aus dem Interface heraus?  Ich meine mit async.  
        //     * 
        //     * Über die IEventListener gehen und parallel oder synchron feuern?  Das muss irgendwie ein Parameter werden
        //     */

        //    //TODO: At the moment only Serial mode!
        //    var tasks = new List<Task>();

        //    foreach (var listener in listenerCollection)
        //    {
        //        var updateTask = Task.Run(() => listener.OnTrigger(EventId));
        //        tasks.Add(updateTask);
        //    }

        //    await Task.WhenAll(tasks);
        //}

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
