using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.MVVM
{
    /// <summary>
    /// Defines a container for managing the application wide instances like ViewModel etc.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Adds a new instance
        /// </summary>
        /// <param name="type">the type</param>
        /// <param name="instance">the instance</param>
        /// <param name="id">the internal ID</param>
        void Add(Type type, object instance,string id);
        /// <summary>
        /// Adds a new service
        /// </summary>
        /// <param name="T">the type</param>
        /// <param name="instance">the instance</param>
        void AddService(Type T, object instance);
        /// <summary>
        /// Determines whether a type exist
        /// </summary>
        /// <param name="t">the type</param>
        /// <returns>true if the type exist otherwise false</returns>
        bool IsAvailable(Type t);
        /// <summary>
        /// Determines whether an instance with the given ID exists
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>true if the id exist otherwise false</returns>
        bool IsAvailable(string id);
        /// <summary>
        /// Gets the instance with the given type
        /// </summary>
        /// <param name="type">the type</param>
        /// <returns>the instance as an object</returns>
        object Get(Type type);
        /// <summary>
        /// Gets the instance with the given type
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>the instance as an object</returns>turns>
        object Get(string id);
        /// <summary>
        /// Removes an instance from the container
        /// </summary>
        /// <param name="id">the id of the instance</param>
        void Remove(string id);
    }
}
