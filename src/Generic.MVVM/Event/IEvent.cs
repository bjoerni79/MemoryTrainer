using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Generic.MVVM.Event
{
    public interface IEvent
    {
        void AddListener(IEventListener listener);
        void RemoveListener(IEventListener listener);
        
        string EventId { get; }

        Task TriggerAsync();
        void Clear();
    }
}
