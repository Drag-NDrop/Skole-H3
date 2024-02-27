using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
/// <summary>
/// Handles thread-safe queueing and dequeuing of integer values
/// </summary>
    internal class BufferQueueWithPulse
    {
        int _id;
        bool _verbose;
        Queue<Bottle> _bufferQueue = new Queue<Bottle>();
        public object _lock = new object();
        int _maxCapacity = 100; // Introduced to make waits more meaningful. We're practising synchronicity and deadlock prevention, not performance.
        string? _type;

        public string? Type
        {
            get
            {
                return _type; // can return null
            }

            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// Create a typeless bufferqueue
        /// </summary>
        /// <param name="id"></param>
        /// <param name="verbose"></param>
        public BufferQueueWithPulse(int id, bool verbose)
        {
            this._id = id;
            this._verbose = verbose;
        }


        /// <summary>
        /// Create a type specific bufferqueue 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="verbose"></param>
        /// <param name="type"></param>

        public BufferQueueWithPulse(int id, bool verbose, string type)
        {
            this._id = id;
            this._verbose = verbose;
            this.Type = type;
        }
        public void Add(Bottle unit) {
            try
            {
                lock (this._lock)// Waits until it can enter the lock. Thread is now locked.
                {
                    while (this._bufferQueue.Count >= this._maxCapacity) // Halt the flow if max capacity is reached.
                    {
                        Console.WriteLine($"Buffer #{this._id} : Awaiting {this._type} consumption.");
                        Monitor.Wait(this._lock);
                    }
                    if (this._verbose)
                    {
                        Console.WriteLine($" - : Buffer #{this._id} had item #{unit.Id} added..");
                    }
                    this._bufferQueue.Enqueue(unit);
                    Monitor.Pulse(this._lock); // Notifies other threads that the lock is available again
                } // The locking mechanism reached the limit of its scope, and will now close on its own. 
            }
            catch (Exception e)
            {
                if (this._verbose && Debugger.IsAttached)
                { // If its asked to be verbose, and a debugger is attached
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(e.InnerException);
                }
            }
        }
        public Bottle Remove() {
            Bottle unit; 
            try
            {
                Thread.Sleep(20);
                lock (this._lock) // Waits until it can enter the lock. 
                { // Thread is now locked.
                    if (this._bufferQueue.Count > 0)
                    {
                        unit = this._bufferQueue.Dequeue();
                        if (this._verbose)
                        {
                            Console.WriteLine($" - : Buffer #{this._id} had item #{unit.Id} consumed..");
                        }
                    }
                    else{ 
                        Console.WriteLine("Queue was empty... waiting for a unit...");
                        while (this._bufferQueue.Count <= 0) { // Halt the flow if the buffer is empty
                            Console.WriteLine($"Buffer #{this._id} : Is empty. Awaiting more {this._type} products..");
                            Monitor.Wait(this._lock);
                        }
                        unit = this._bufferQueue.Dequeue();
                    }
                    Monitor.Pulse(this._lock);
                }
                return unit;
            }
            catch (Exception e)
            {
                if (this._verbose && Debugger.IsAttached)
                { // If the object is configured to be verbose, and a debugger is attached
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(e.InnerException);
                }
                Console.WriteLine("Warning: Buffer encountered an error, and returned a null-value unit.");
                return null;
            }
            
        }
    }
}
