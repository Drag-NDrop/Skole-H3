using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    /// <summary>
    /// Pull: The buffer actively moves data from its defined input queues, to one of its input queues. SharedRessource.Buffer.OutputQueue => SharedRessource.Buffer.InputQueue
    /// Push: The buffer actively moves data from its input queue, to one of its output queues.         SharedRessource.Buffer.InputQueue  => Sharedressource.Buffer.OutputQueue
    /// </summary>
    internal class ProsumerWithPulse
    {
        List<BufferQueueWithPulse> _inputBuffers = new List<BufferQueueWithPulse>(); // Shared ressource input queues
        List<BufferQueueWithPulse> _outputBuffers = new List<BufferQueueWithPulse>(); // Shared ressource output queues

        public ProsumerWithPulse(List<BufferQueueWithPulse> InputBuffers, List<BufferQueueWithPulse> OutputBuffers )
        {
            this._inputBuffers = InputBuffers;
            this._outputBuffers = OutputBuffers;
        }

        /// <summary>
        /// Sorting mechanism design to run in an eternal loop. It runs until ShouldStop state changes.
        /// </summary>
        /// <param name="callback"></param>
        internal void SortUnits(object callback) {
            while(Program.ShouldStop != true) { 
                foreach (BufferQueueWithPulse buffer in _inputBuffers)
                {
                    try
                    {
                        Bottle bottle = buffer.Remove();
                        {
                            try {
                                _outputBuffers.FirstOrDefault(x => x.Type == bottle.Type).Add(bottle);
                                            // In this context, x is a BufferQueueWithPulse object.
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Something happened in the prosumer(the splitter)" );
                                throw;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// Add x to internal queue.
        /// Thread-safe operation.
        /// </summary>
        internal void StartSorting()
        {
            {
                object callback = new object();
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.SortUnits));
            }
        }
    }
}
