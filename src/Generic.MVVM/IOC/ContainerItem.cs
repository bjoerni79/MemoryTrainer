using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.MVVM.IOC
{
    /// <summary>
    /// Internal structure of a container item
    /// </summary>
    internal class ContainerItem
    {
        /// <summary>
        /// Creates a new ContainerItem
        /// </summary>
        /// <param name="t">the type</param>
        /// <param name="instance">the instance</param>
        /// <param name="id">the id</param>
        internal ContainerItem(Type t, object instance, string id)
        {
            ItemType = t;
            ItemInstance = instance;
            ItemId = id;
        }

        /// <summary>
        /// Returns the Item Type
        /// </summary>
        internal Type ItemType { get; private set; }

        /// <summary>
        /// Returns the Item Instance
        /// </summary>
        internal Object ItemInstance { get; private set; }

        /// <summary>
        /// Returns the Item ID
        /// </summary>
        internal string ItemId { get; private set; }
    }
}
