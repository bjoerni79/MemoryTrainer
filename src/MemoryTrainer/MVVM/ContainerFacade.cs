using MemoryTrainer.MMVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MemoryTrainer.MVVM
{
    public class ContainerFacade
    {
        public ContainerFacade()
        {

        }

        private IContainer Container
        {
            get
            {
                //var container = Application.Current.Resources.FindName("Container");
                //return container as IContainer;

                IContainer container = null;
                foreach (var currentInstance in Application.Current.Resources.Values)
                {
                    if (currentInstance is IContainer)
                    {
                        container = currentInstance as IContainer;
                        break;
                    }
                }

                return container;
            }
        }

        public T Get<T>() where T: class
        {
            IContainer container = Container;

            if (container == null)
            {
                throw new ContainerException("Could not resolve container instance");
            }

            var instance = container.Get(typeof(T));
            if (instance == null)
            {
                throw new ContainerException("Could not resolve requested instance");
            }

            return instance as T;
        }

        public T Get<T>(string id) where T : class
        {
            IContainer container = Container;

            if (container == null)
            {
                throw new ContainerException("Could not resolve container instance");
            }

            var instance = container.Get(id);
            if (instance == null)
            {
                throw new ContainerException("Could not resolve requested instance");
            }

            

            if (!(instance is T))
            {
                throw new ContainerException("Cannot conver instance to the given type");
            }

            return instance as T;
        }

        public void Add<T>(T vm, string pageId) where T:ViewModelBase
        {
            Container.Add(typeof(ViewModelBase), vm, pageId);
        }

        public void AddUnique<T>(T instance,string id)
        {
            var available = Container.IsAvailable((typeof(T)));
            if (available)
            {
                throw new ContainerException("Unique instance already exists");
            }

            Container.Add(typeof(T), instance, id);
        }

        public void Remove(string pageId)
        {
            var container = Container;
            container.Remove(pageId);
        }
    }
}
