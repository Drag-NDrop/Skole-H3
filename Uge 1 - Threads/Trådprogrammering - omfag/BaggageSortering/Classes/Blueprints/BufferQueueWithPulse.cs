using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes.Blueprints
{
    /// <summary>
    /// Handles thread-safe queueing and dequeuing of units
    /// </summary>
    internal abstract class BufferQueueWithPulse
    {
        private object _lock = new object();
        private int _maxCapacity = 100; // Introduced to make waits more meaningful. We're practising synchronicity and deadlock prevention, not performance.
        private Queue<Unit> _bufferQueue = new Queue<Unit>();
        private bool _verbose;
        private int _id;
        private string _type;

        public string Type
        {
            get
            {
                return _type; // can return null
            }

            private set
            {
                _type = value;
            }
        }

        public int MaxCapacity
        {
            get
            {
                return _maxCapacity;
            }

            private set
            {
                _maxCapacity = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }


        /// <summary>
        /// Thread-safe queueing and dequeuing of units. Utilizes a .NET Standard queue internally.
        /// </summary>
        /// <param name="id">Unique identifier of objects derived from the class</param>
        /// <param name="verbose">Turns visual output on/off</param>
        /// <param name="type">Aids the visual output from the class</param>
        /// <param name="maxCapacity">Used to describe the maximum capacity of the buffer. Not necessary, but makes the code more testable.</param>

        public BufferQueueWithPulse(int id, bool verbose, string type, int maxCapacity)
        {
            Id = id;
            _verbose = verbose;
            _type = type; // Used to describe the type of unit that is produced/consumed
            MaxCapacity = maxCapacity; // Used to describe the maximum capacity of the buffer. Not necessary, but makes the code more testable.
        }

        /// <summary>
        /// Adds a unit to the bufferqueue
        /// </summary>
        /// <param name="unit"> A unit or a descendant of the type Unit. </param>
        public void Add(Unit unit)
        {
            try
            {
                lock (_lock)// Waits until it can enter the lock. Thread is now locked.
                {
                    while (_bufferQueue.Count >= MaxCapacity) // Halt the flow if max capacity is reached.
                    {
                        Console.WriteLine($"Buffer #{Id} : Awaiting {_type} consumption.");
                        Monitor.Wait(_lock); // Release the lock and waits until the lock is available again. Perhaps a change to the while-condition will have happened next time the lock is available.
                    }

                    try { _bufferQueue.Enqueue(unit); } catch (Exception e) { Console.WriteLine(e); } // Adds the unit to the queue

                    if (_verbose)
                    {
                        Console.WriteLine($" - : Buffer #{Id} had item #{unit.Id} added..");
                    }
                    Monitor.Pulse(_lock); // Notifies other threads that the lock is available again
                } // The locking mechanism reached the limit of its scope, and will now close on its own. 
            }
            catch (Exception e)
            {
                if (_verbose && Debugger.IsAttached)  // If the object is configured to be verbose, and a debugger is attached
                {
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(e.InnerException);
                }
            }
        }
        /// <summary>
        /// Removes a unit from the bufferqueue
        /// </summary>
        /// <returns>The removed Unit.</returns>
        public Unit Remove()
        {
            Unit unit;
            try
            {
                lock (_lock) // Waits until it can enter the lock. 
                { // Thread is now locked.
                    if (_bufferQueue.Count > 0)
                    {
                        unit = _bufferQueue.Dequeue();  // Due to the nature of the BufferQueue object, this will wait until it can dequeue an item.
                        if (_verbose)
                        {
                            Console.WriteLine($" - : Buffer #{Id} had item #{unit.Id} consumed..");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Queue was empty... waiting for a unit...");
                        while (_bufferQueue.Count <= 0)
                        { // Halt the flow if the buffer is empty
                            Console.WriteLine($"Buffer #{Id} : Is empty. Awaiting more {_type} products..");
                            Monitor.Wait(_lock);
                        }
                        unit = _bufferQueue.Dequeue();
                    }
                    Monitor.Pulse(_lock);
                }
                return unit;
            }
            catch (Exception e)
            {
                if (_verbose && Debugger.IsAttached) // If the object is configured to be verbose, and a debugger is attached
                {
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(e.InnerException);
                }
                Console.WriteLine("Warning: Buffer encountered an error, and returned a null-value unit.");
                return null;
            }

        }
    }
}
