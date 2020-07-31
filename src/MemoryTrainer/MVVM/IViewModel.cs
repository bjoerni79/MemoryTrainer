using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.MVVM
{
    /// <summary>
    /// Represents the view model role for the page concept
    /// </summary>
    public interface IViewModel
    {
        void Init(IPage page);
    }
}
