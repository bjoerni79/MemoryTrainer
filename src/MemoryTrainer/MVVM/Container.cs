using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace MemoryTrainer.MVVM
{
    public class Container : IContainer
    {
        private List<ContainerItem> itemList;

        public Container()
        {
            itemList = new List<ContainerItem>();
        }

        public void Add(Type type, object instance, string id)
        {
            var item = new ContainerItem(type, instance, id);
            itemList.Add(item);
        }

        public void AddService(Type type, object instance)
        {
            var item = new ContainerItem(type, instance, null);
            itemList.Add(item);
        }

        public object Get(Type type)
        {
            if (!IsAvailable(type))
            {
                throw new ContainerException("Type could not be found");
            }

            return GetItem(type);
        }

        public object Get(string id)
        {
            if (!IsAvailable(id))
            {
                throw new ContainerException("Id could not be found");
            }

            return GetItem(id);
        }

        public bool IsAvailable(Type t)
        {
            var item = GetItem(t);
            return item != null;
        }

        public bool IsAvailable(string id)
        {
            var item = GetItem(id);
            return item != null;
        }

        public void Remove(string id)
        {
            if (IsAvailable(id))
            {
                var containerItem = GetContainerItem(id);
                itemList.Remove(containerItem);
            }
        }

        private object GetItem (Type t)
        {
            var item = itemList.FirstOrDefault(curItem => curItem.ItemType == t);
            
            return item?.ItemInstance;
        }

        private object GetItem(string id)
        {
            var item = itemList.FirstOrDefault(curItem => curItem.ItemId != null && curItem.ItemId.Equals(id));
            return item?.ItemInstance;
        }

        private ContainerItem GetContainerItem (string id)
        {
            var item = itemList.FirstOrDefault(curItem => curItem.ItemId != null && curItem.ItemId.Equals(id));
            return item;
        }
    }
}
