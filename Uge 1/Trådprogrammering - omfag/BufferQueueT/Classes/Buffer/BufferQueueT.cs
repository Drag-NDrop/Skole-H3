using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferQueueT.Classes.Buffer
{
    /// <summary>
    /// Handles thread-safe queueing and dequeuing of integer values
    /// </summary>
    internal class BufferQueueT<T>
    {
        int _id; // Unique identifier for the buffer
        string _name; // Friendly/display name for the buffer
        string _type; // Used to described what kind of function the buffer fills
        bool _verbose; // Used to determine if the buffer should be verbose or not
        Queue<T> _bufferQueue = new Queue<T>(); // The queue that will hold the values
        public object _lock = new object(); // The lock that will be used to ensure thread safety
        int _maxCapacity = 10000; // Introduced to make Monitor.waits more meaningful


        public BufferQueueT(int id, string name, int maxCapacity, bool verbose, string type)
        {
            _id = id;
            _verbose = verbose;
            _name = name;
            _type = type;
            _maxCapacity = maxCapacity;
        }

        public virtual string BufferFullMessage()
        {
            return "Buffer is full.. Awaiting consumption.";
        }

        public virtual string BufferEmptyMessage()
        {
            return "Buffer is empty. Awaiting products..";
        }

        public virtual string BufferAddMessage(string id)
        {
            return $"[{_type}] #{_id} had item #{id} added..."; // Item identifier could be a unique ID or serial number of the item
        }
        public virtual string BufferRemoveMessage(string id)
        {
            return $"[{_type}] #{_id} had item #{id} removed..."; // Item identifier could be a unique ID or serial number of the item
        }
        public void Add(T unit)
        {
            try
            {
                lock (_lock)// Waits until it can enter the lock. Thread is now locked.
                {
                    while (_bufferQueue.Count >= _maxCapacity) // Halt the flow if max capacity is reached.
                    {
                        Monitor.Wait(_lock);
                        Console.WriteLine(BufferFullMessage());
                    }
                    if (_verbose)
                    {
                        if (TestPropertyId(unit) != "")
                        {
                            Console.WriteLine(BufferAddMessage(TestPropertyId(unit)));
                        }
                        else
                        {
                            Console.WriteLine(BufferAddMessage("")); // If the object doesn't have an id property, we'll just pass an empty string
                        }
                    }
                    _bufferQueue.Enqueue(unit);
                    Monitor.Pulse(_lock); // Notifies other threads that the lock is available again
                } // The locking mechanism reached the limit of its scope, and will now close on its own. 
            }
            catch (Exception e)
            {
                if (_verbose && Debugger.IsAttached)
                { // If its asked to be verbose, and a debugger is attached
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(e.InnerException);
                }
            }
        }

        /// <summary>
        /// Removes(dequeues) an item from the buffer.
        /// Amount specifies if the operation should remove more than one item.
        /// If amount is greater than 1, the operation will remove the specified amount of items. And return an array of the removed items.
        /// This allows us to operate with the buffer in bulk, and allow for each thread to take on a larger workload.
        /// </summary>
        /// <param name="amount">If greater than 1, T[] is returned.</param>
        public void Remove(T amount)
        {
            try
            {
                lock (_lock) // Waits until it can enter the lock. Thread is now locked.
                {

                    if (_bufferQueue.Count > 0)
                    {
                        T unit = _bufferQueue.Dequeue();

                        if (_verbose)
                        {
                            if (TestPropertyId(unit) != "")
                            {
                                Console.WriteLine(BufferRemoveMessage(TestPropertyId(unit)));
                            }
                            else
                            {
                                Console.WriteLine(BufferRemoveMessage("")); // If the object doesn't have an id property, we'll just pass an empty string
                            }
                        }
                    }
                    else
                    {
                        while (_bufferQueue.Count <= 0)
                        { // Halt the flow if the buffer is empty
                            Monitor.Wait(_lock);
                            Console.WriteLine(BufferEmptyMessage());
                        }
                        _bufferQueue.Dequeue();
                    }
                    Monitor.Pulse(_lock);
                }

            }
            catch (Exception e)
            {
                if (_verbose && Debugger.IsAttached)
                { // If the object is configured to be verbose, and a debugger is attached
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(e.InnerException);
                }
            }
        }


        public string TestPropertyId(T unit)
        {
            string id = "";
            bool hasProperty = HasItemIdentifierProperty(unit); // Checks if the object has a property called "id"
            if (hasProperty)                                     // It's also called reflection, and is a very powerful tool. Performance is not great, but it's very useful.
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty("Id");
                id = propertyInfo.GetValue(unit, null).ToString();
            }
            else
            {
                switch (unit.GetType().Name.ToLower())
                {
                    case "int32":
                        {
                            id = unit.ToString();
                            break;
                        }
                    case "string":
                        {
                            id = unit.ToString();
                        }
                        break;

                    default:
                        {
                            // Should support more primitive types, but for now we'll just return an empty string
                            id = "";
                            break;
                        }
                }
            }
            return id;
        }
        public bool HasItemIdentifierProperty<T>(T item)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty("Id");
            return propertyInfo != null;
        }
    }
}
