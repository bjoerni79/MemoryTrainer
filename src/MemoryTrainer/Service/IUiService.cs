﻿using MemoryTrainer.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Service
{
    public interface IUiService
    {
        IPage CreatePage(PageSelection element,string pageId);

        IPage ShowResultOverview(string id);

        void Close(string pageId);

        bool ShowDialog(string message, string caption);

        string ShowOpenFileDialog();

        string ShowSaveFileDialog();
    }
}
