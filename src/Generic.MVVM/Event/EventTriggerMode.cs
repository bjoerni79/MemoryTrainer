using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.MVVM.Event
{
    /// <summary>
    /// Specifies the trigger mode
    /// </summary>
    public enum EventTriggerMode
    {
        /// <summary>
        /// the event listener are triggered one by one
        /// </summary>
        Serial,
        /// <summary>
        /// The event listener are triggered at the same time
        /// </summary>
        Parallel
    }
}
