using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.MVVM.Event
{
    /// <summary>
    /// Describes the consuming part of an event
    /// </summary>
    public interface IEventListener
    {
        /// <summary>
        /// Receiving method by the trigger
        /// </summary>
        /// <param name="eventId">the event id</param>
        void OnTrigger(string eventId);
    }
}
