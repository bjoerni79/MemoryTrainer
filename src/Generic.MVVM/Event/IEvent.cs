using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Generic.MVVM.Event
{
    /// <summary>
    /// Describes an event 
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Adds a new listener
        /// </summary>
        /// <param name="listener">the listener instance</param>
        void AddListener(IEventListener listener);
        /// <summary>
        /// Removes a listener
        /// </summary>
        /// <param name="listener">the listener instance</param>
        void RemoveListener(IEventListener listener);
        /// <summary>
        /// Returns the event ID
        /// </summary>
        string EventId { get; }
        /// <summary>
        /// Triggers the event synchronously
        /// </summary>
        void Trigger();
        /// <summary>
        /// Triggers the event asynchronously
        /// </summary>
        /// <returns>The task instance</returns>
        //Task TriggerAsync();
        /// <summary>
        /// Clears all listener
        /// </summary>
        void Clear();
    }
}
