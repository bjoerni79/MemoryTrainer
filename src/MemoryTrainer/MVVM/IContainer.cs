using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.MVVM
{
    public interface IContainer
    {
        void Add(Type type, object instance,string id);

        void AddService(Type T, object instance);

        bool IsAvailable(Type t);

        bool IsAvailable(string id);

        object Get(Type type);

        object Get(string id);

        void Remove(string id);
    }
}
