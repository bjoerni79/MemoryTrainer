using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace MemoryTrainer.MVVM
{
    internal class ContainerItem
    {
        internal ContainerItem(Type t, object instance, string id)
        {
            ItemType = t;
            ItemInstance = instance;
            ItemId = id;
        }

        internal Type ItemType { get; private set; }

        internal Object ItemInstance { get; private set; }

        internal string ItemId { get; private set; }
    }
}
