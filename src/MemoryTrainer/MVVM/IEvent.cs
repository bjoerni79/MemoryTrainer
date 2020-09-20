using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.MVVM
{
    /// <summary>
    /// Event description for listening and triggering updates in views
    /// </summary>
    public interface IEvent<T> where T:EventArgs
    {
        void Trigger(T args);
    }
}
