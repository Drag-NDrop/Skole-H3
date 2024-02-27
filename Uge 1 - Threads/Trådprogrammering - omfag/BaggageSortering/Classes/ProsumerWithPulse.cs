using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes
{
    /// <summary>
    /// Pull: The buffer actively moves data from its defined input queues, to one of its input queues. SharedRessource.Buffer.OutputQueue => SharedRessource.Buffer.InputQueue
    /// Push: The buffer actively moves data from its input queue, to one of its output queues.         SharedRessource.Buffer.InputQueue  => Sharedressource.Buffer.OutputQueue
    /// </summary>
    internal class ProsumerWithPulse
    {
        List<Check_inConveyorBelt> _inputBuffers = new List<Check_inConveyorBelt>(); // Shared ressource input queues
        List<GateConveyorBelt> _outputBuffers = new List<GateConveyorBelt>(); // Shared ressource output queues

        public ProsumerWithPulse(List<Check_inConveyorBelt> InputBuffers, List<GateConveyorBelt> OutputBuffers)
        {
            _inputBuffers = InputBuffers;
            _outputBuffers = OutputBuffers;
        }

        /// <summary>
        /// Sorting mechanism design to run in an eternal loop. It runs until ShouldStop state changes.
        /// </summary>
        /// <param name="callback"></param>
        internal void SortUnits(object callback)
        {
            while (Program.ShouldStop != true)
            {
                foreach (Check_inConveyorBelt buffer in _inputBuffers)
                {
                    try
                    {
                        Baggage unit = buffer.Remove();
                        {
                            try
                            {
                                /* While this shouldn't break "per se", it's inefficient as it's likely that the topmost buffer that matches the type will most often, if not always be the one that's used.
                                // This is a design flaw, and should be fixed.
                                // Or.. it should be explained that our luggage system only support one open destination at the time.
                                // Will be fixed if i find the time.

                                // This is a LINQ query. It's a bit like a foreach loop, but it's a bit more efficient.
                                // It takes the unit we just removed, checks its type , and tries to find a buffer that matches the type. Then adds the unit to that buffer.
                                //_outputBuffers.FirstOrDefault(x => x.Type == unit.Type).Add(unit);
                                // In this context, x is a BufferQueueWithPulse object.

                                // If the unit type doesn't match any of the output buffers, it will be added to the first output buffer. This is not optimal.
                                // It's a design flaw, and should be fixed.

                                */
                                //Extend the bufferQueues to be able to inform of their availability, and use that to determine which buffer to use.
                                GateConveyorBelt bestMatchOutputBuffer = null;
                                while (bestMatchOutputBuffer == null)
                                {
                                    bestMatchOutputBuffer = _outputBuffers.FirstOrDefault(x => x.Destination == unit.Destination);
                                    if (bestMatchOutputBuffer == null)
                                    {
                                        Console.WriteLine($"Found no matching destination for unit destination: {unit.Destination}");
                                        Console.WriteLine("This was the options:");
                                        foreach (GateConveyorBelt failingbuffer in _outputBuffers)
                                        {
                                            Console.WriteLine(failingbuffer.Destination);
                                        }
                                        Console.WriteLine("Scanning for an avilable outputbuffer that matches the unit type...");
                                    }
                                }
                                if (bestMatchOutputBuffer != null)
                                {
                                    bestMatchOutputBuffer.Add(unit);
                                }
                                else
                                {
                                    Console.WriteLine("No output buffer found that matches the unit type");
                                }

                            }

                            catch (NullReferenceException ex)
                            {
                                if (ex.HResult == -2147467261)
                                {
                                    // Handle the specific NullReferenceException with HRESULT -2147467261
                                    Console.WriteLine("Caught NullReferenceException with specific HRESULT");
                                    Console.WriteLine("Does the expected unit type of the output buffer, correspond with the unit type from your producers/input buffers?");
                                }

                                else throw;
                            }

                            catch (Exception)
                            {
                                Console.WriteLine("Something happened in the prosumer(the splitter)");
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
        /// Signals the object to start sorting the objects from its allocated input queues, to its allocated output queues. 
        /// It does so in its own thread, relying upon the thread-safe operations of the allocated bufferqueue objects.
        /// Thread-safe operation.
        /// </summary>
        internal void StartSorting()
        {
            {
                object callback = new object();
                ThreadPool.QueueUserWorkItem(new WaitCallback(SortUnits));
            }
        }
    }
}
