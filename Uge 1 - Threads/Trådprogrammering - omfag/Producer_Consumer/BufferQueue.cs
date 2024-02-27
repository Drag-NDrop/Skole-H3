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
    internal class BufferQueue
    {
        int _id;
        bool _verbose;
        Queue<int> _bufferQueue = new Queue<int>();
        public object _lock = new object();
        public bool Available = true;
        

        public BufferQueue(int id, bool verbose)
        {
            this._id = id;
            this._verbose = verbose;
        }
        public void Add(int unit) {
            try
            {
                Monitor.Enter(this._lock); // Waits until it can enter the lock
                this.Available = false;
                this._bufferQueue.Enqueue(unit);
                if (this._verbose)
                {
                    Console.WriteLine($" - : Buffer #{this._id} had item #{unit} added..");
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
            finally
            {
                this.Available = true;
                Monitor.Exit(this._lock); // Release the lock
            }

            
            if (this._verbose) { 
                Console.WriteLine($" + : Buffer #{this._id} had item #{unit.ToString()} added..");
            }
        }
        public void Remove(int amount) {
            try
            {
                for (int i = 0; i < amount; i++) // Begins adding the units it was told
                { 
                    Monitor.Enter(this._lock); // Waits until it can enter the lock
                    this.Available = false;
                    if(this._bufferQueue.Count > 0) { 
                        if (this._verbose)
                        {
                            Console.WriteLine($" - : Buffer #{this._id} had item #{this._bufferQueue.Dequeue()} consumed..");
                        }
                        else {
                            this._bufferQueue.Dequeue();
                        }
                    }
                    else if (this._verbose) { Console.WriteLine("Queue was empty... No units removed."); }
                }
            }
            catch (Exception e)
            {
                if (this._verbose && Debugger.IsAttached) { // If its asked to be verbose, and a debugger is attached
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(e.InnerException);
                }
                throw;
            }
            finally {
                this.Available = false;
                Monitor.Exit(this._lock); // Release the lock
            }
        }
    }
}
