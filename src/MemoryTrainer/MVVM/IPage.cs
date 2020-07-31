using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.MVVM
{
    /// <summary>
    /// Interface for the page view implementation
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// Returns the current ID of the page
        /// </summary>
        /// <returns></returns>
        string GetId();

        void SetFocus();
    }
}
