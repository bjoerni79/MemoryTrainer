using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.MVVM.Event
{
    public sealed class EventController
    {
        private readonly object lockInstance = new object();
        private List<IEvent> eventCollection;

        public EventController()
        {
            eventCollection = new List<IEvent>();
        }

        public void Add(IEvent eventInstance)
        {
            if (eventInstance == null)
            {
                throw new ArgumentNullException("eventInstance");
            }

            // Run this in thread safe environment
            lock(lockInstance)
            {
                // If the id already exist, throw an exception
                var olderInstance = eventCollection.FirstOrDefault((curEvent) => curEvent.EventId.Equals(eventInstance.EventId));
                if (olderInstance != null)
                {
                    throw new ArgumentException("The event ID already exists! Please choose another one");
                }

                eventCollection.Add(eventInstance);
            }
        }

        public void Remove(string eventId)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                throw new ArgumentException("ID is null or empty!");
            }

            lock(lockInstance)
            {
                var eventInstance = eventCollection.FirstOrDefault((curEvent) => curEvent.EventId.Equals(eventId));
                if (eventInstance != null)
                {
                    eventCollection.Remove(eventInstance);
                }
            }
        }

        public IEvent GetEvent(string eventId)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                throw new ArgumentException("ID is null or empty!");
            }

            lock (lockInstance)
            {
                var eventInstance = eventCollection.FirstOrDefault(curEvent => curEvent.EventId.Equals(eventId));
                if (eventInstance == null)
                {
                    throw new ArgumentException("event cannot be found!");
                }

                return eventInstance;
            }
        }

        public IEnumerable<string> GetIds(string eventId)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                throw new ArgumentException("ID is null or empty!");
            }

            lock(lockInstance)
            {
                var idCollection = eventCollection.Select(curEvent => curEvent.EventId);
                var newList = new List<string>(idCollection);

                return newList;
            }
        }
    }
}
