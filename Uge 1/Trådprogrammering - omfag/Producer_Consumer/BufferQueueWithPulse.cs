using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer_Consumer
{
/// <summary>
/// Handles thread-safe queueing and dequeuing of integer values
/// </summary>
    internal class BufferQueueWithPulse
    {
        int _id;
        bool _verbose;
        Queue<int> _bufferQueue = new Queue<int>();
        public object _lock = new object();
        int _maxCapacity = 10000; // Introduced to make waits more meaningful
        

        public BufferQueueWithPulse(int id, bool verbose)
        {
            this._id = id;
            this._verbose = verbose;
        }
        public void Add(int unit) {
            try
            {
                lock (this._lock)// Waits until it can enter the lock. Thread is now locked.
                {
                    while (this._bufferQueue.Count <= this._maxCapacity) // Halt the flow if max capacity is reached.
                    {
                        Monitor.Wait(this._lock);
                        Monitor.Pulse(this._lock);
                        Console.WriteLine("Buffer is full.. Awaiting consumption.");
                    }
                    this._bufferQueue.Enqueue(unit);
                    if (this._verbose)
                    {
                        Console.WriteLine($" - : Buffer #{this._id} had item #{unit} added..");
                    }
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
        public void Remove(int amount) {
            try
            {
                lock (this._lock) // Waits until it can enter the lock. Thread is now locked.
                {
                    if (this._bufferQueue.Count > 0)
                    {
                        if (this._verbose)
                        {
                            Console.WriteLine($" - : Buffer #{this._id} had item #{this._bufferQueue.Dequeue()} consumed..");
                        }
                        else
                        {
                            this._bufferQueue.Dequeue();
                        }
                    }
                    else{ 
                        Console.WriteLine("Queue was empty... waiting for a unit...");
                        while (this._bufferQueue.Count == 0) { // Halt the flow if the buffer is empty
                            Monitor.Wait(this._lock);
                            Monitor.Pulse(this._lock);
                            Console.WriteLine("Buffer is empty. Awaiting products..");
                        }
                        this._bufferQueue.Dequeue();
                    }
                    Monitor.PulseAll(this._lock);
                }
               
            }
            catch (Exception e)
            {
                if (this._verbose && Debugger.IsAttached)
                { // If its asked to be verbose, and a debugger is attached
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(e.InnerException);
                }
                throw;
            }
        }
    }
}
