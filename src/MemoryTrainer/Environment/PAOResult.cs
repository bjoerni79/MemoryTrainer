using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Environment
{
    public class PAOResult
    {
        public string Comment { get; set; }

        public string DeckTitle { get; set; }

        public PAOResult()
        {
            Items = new List<PAOResultItem>();
        }

        public List<PAOResultItem> Items
        {
            get;set;
        }
    }
}
