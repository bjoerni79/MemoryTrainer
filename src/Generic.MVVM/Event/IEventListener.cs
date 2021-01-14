using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.MVVM.Event
{
    public interface IEventListener
    {
        void OnTrigger(string eventId);
    }
}
