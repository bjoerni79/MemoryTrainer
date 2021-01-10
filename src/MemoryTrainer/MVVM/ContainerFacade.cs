using System.Windows;

namespace MemoryTrainer.MVVM
{
    /// <summary>
    /// Helper class for accessing the IContainer implementation
    /// </summary>
    public class ContainerFacade
    {
        /// <summary>
        /// Creates a new ContainerFacade
        /// </summary>
        public ContainerFacade()
        {

        }

        private IContainer Container
        {
            get
            {
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

        /// <summary>
        /// Gets the instance from the container in the expected type
        /// </summary>
        /// <typeparam name="T">the expected type</typeparam>
        /// <returns>the instance</returns>
        /// <remarks>Throws an ContainerException if not possible</remarks>
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

        /// <summary>
        /// Gets the instance based on a given ID in the expected type
        /// </summary>
        /// <typeparam name="T">the type</typeparam>
        /// <param name="id">the id</param>
        /// <returns>the instance</returns>
        /// <remarks>Throws an ContainerException if not possible</remarks>
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

        /// <summary>
        /// Adds a new viewmodel to the container
        /// </summary>
        /// <typeparam name="T">the type of the viewm odel</typeparam>
        /// <param name="vm">the view model instance</param>
        /// <param name="pageId">the page id</param>
        public void Add<T>(T vm, string pageId) where T:ViewModelBase
        {
            Container.Add(typeof(ViewModelBase), vm, pageId);
        }

        /// <summary>
        /// Adds a unique instance of a type to the container
        /// </summary>
        /// <typeparam name="T">the type</typeparam>
        /// <param name="instance">the instance</param>
        /// <param name="id">the id</param>
        /// <remarks>Throws an ContainerException if the type already exists</remarks>
        public void AddUnique<T>(T instance,string id)
        {
            var available = Container.IsAvailable((typeof(T)));
            if (available)
            {
                throw new ContainerException("Unique instance already exists");
            }

            Container.Add(typeof(T), instance, id);
        }

        /// <summary>
        /// Removes a view model from the container
        /// </summary>
        /// <param name="pageId">the pageid</param>
        public void Remove(string pageId)
        {
            var container = Container;
            container.Remove(pageId);
        }

        public bool Exists(string pageId)
        {
            var container = Container;
            bool exists = container.IsAvailable(pageId);
            return exists;
        }
    }
}
