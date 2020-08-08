using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Environment
{
    public class PAOResult
    {
        public List<PAOResultItem> resultItems;

        public PAOResult()
        {
            resultItems = new List<PAOResultItem>();
        }

        public void Add(PAOResultItem item)
        {
            resultItems.Add(item);
        }

        public IEnumerable<PAOResultItem> Items
        {
            get
            {
                //
                //  Create a copy of the list and return it
                //
                var newList = new List<PAOResultItem>(resultItems);
                return newList;
            }
        }
    }
}
