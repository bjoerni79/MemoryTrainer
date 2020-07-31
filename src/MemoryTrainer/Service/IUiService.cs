using MemoryTrainer.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Service
{
    public interface IUiService
    {
        IPage CreatePage(PageSelection element,string pageId);

        void Close(string pageId);

        bool ShowDialog(string message);
    }
}
