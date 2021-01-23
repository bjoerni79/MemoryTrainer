using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.MVVM.Event
{
    public class EventTriggerException : GenericMvvmException
    {
        public string EventId { get; private set; }


        public EventTriggerException(string eventId, string message) : base(message)
        {
            EventId = eventId;
        }

        public EventTriggerException(string eventId, string message, Exception inner): base(message,inner)
        {
            EventId = eventId;
        }

    }
}
