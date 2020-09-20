using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.MVVM
{
    public class Event<T> : IEvent<T> where T:EventArgs
    {
        private Action<T> executer;

        public Event(Action<T> action)
        {
            executer += action;
        }

        public void Trigger(T args)
        {
            executer(args);
        }

    }
}
