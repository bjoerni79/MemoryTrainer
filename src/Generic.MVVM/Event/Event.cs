using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.MVVM.Event
{
    public class Event : IEvent
    {
        private List<IEventListener> listenerCollection;
        private EventTriggerMode mode;

        public Event(string eventId, EventTriggerMode mode)
        {
            EventId = eventId;
            this.mode = mode;
            listenerCollection = new List<IEventListener>();
        }

        public Event(string eventId) : this(eventId, EventTriggerMode.Serial)
        {
            // empty
        }

        public string EventId { get; private set; }

        public void AddListener(IEventListener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            listenerCollection.Add(listener);
        }

        public void RemoveListener(IEventListener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            listenerCollection.Remove(listener);
        }

        public void Clear()
        {
            listenerCollection = new List<IEventListener>();
        }

        public async Task TriggerAsync()
        {

            /*
             * Todo:
             * 
             * Wie implementiert man eine Task Umgebung aus dem Interface heraus?  Ich meine mit async.  
             * 
             * Über die IEventListener gehen und parallel oder synchron feuern?  Das muss irgendwie ein Parameter werden
             */

            throw new NotImplementedException();
        }
    }
}
