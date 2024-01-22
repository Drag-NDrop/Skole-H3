using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadPools_SynchronizationExcersise
{

    #region Opgave 1
    /*
    class Program
    {
        static int counter = 0;
        static object _lockingMechanism = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Thread Pool Execution");
            Console.WriteLine("Two threads.");
            Console.WriteLine("One thread adds 2, to a shared resource.");
            Console.WriteLine("One thread subtracts 1, from the same shared resource.");
            Console.WriteLine("-------------------------------------------------------");

            ThreadPool.QueueUserWorkItem(new WaitCallback(Program.AddSome));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Program.SubtractSome));
        }
        
        static void AddSome(object callback)
        {
            // Set an exit condition for the loop
            while(Program.counter <= 1000) { 
                try
                {
                    // Enter a Monitor state on the lockingMechanism(_lock)
                    Monitor.Enter(Program._lockingMechanism);
                    // Increase the shared resource counter by 2.
                    Program.counter = Program.counter + 2;
                }

                catch
                { Console.WriteLine($"Failed to add some..."); } // In case something goes wrong

                finally {
                    // Inform the user what happened in the thread
                    Console.WriteLine("Added 2. New value: " +Program.counter.ToString());
                    // Release the locking mechanism
                    Monitor.Exit(Program._lockingMechanism);
                    // Sleep 1 sec
                    Thread.Sleep(1000);
                }
            }
        }

        static void SubtractSome(object callback)
        {
            // Set an exit condition for the loop
            while (Program.counter <= 1000) { 
                try
                {
                    // Enter a Monitor state on the lockingMechanism(_lock)
                    Monitor.Enter(Program._lockingMechanism);
                    // Decrease the shared resource counter by 1.
                    Program.counter = Program.counter - 1;
                }

                catch
                { Console.WriteLine($"Failed to subtract some..."); } // In case something goes wrong

                finally {
                    // Inform the user what happened in the thread
                    Console.WriteLine("Subtracted 1. New value: " + Program.counter.ToString());
                    // Release the locking mechanism
                    Monitor.Exit(Program._lockingMechanism); 
                    // Sleep 1 sec
                    Thread.Sleep(1000);
                }
            }
        }
    }
    */
    #endregion

    #region Opgave 2+3
    class Program
    {
        static int progressCounter = 0;
        static int amountOfChars = 60;
        static object _lockingMechanism = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Thread Pool Execution");
            Console.WriteLine("Two threads.");
            Console.WriteLine($"One thread adds writes {amountOfChars.ToString()} #'s.");
            Console.WriteLine($"One thread adds writes {amountOfChars.ToString()} *'s.");
            Console.WriteLine("-------------------------------------------------------");

            ThreadPool.QueueUserWorkItem(new WaitCallback(Program.WriteStars));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Program.WriteHashtags));
            Console.ReadKey();
        }

        static void WriteStars(object callback)
        {
            // Set an exit condition for the loop
            while (Program.progressCounter <= 6000)
            {
                try
                {
                    // Enter a Monitor state on the lockingMechanism(_lock)
                    Monitor.Enter(Program._lockingMechanism);
                    // Increase the shared resource counter by $amountOfChars.
                    Program.progressCounter = Program.progressCounter + Program.amountOfChars;
                    // Loop the amount of chars, and write a star for each
                    for (int i = 0; i < Program.amountOfChars; i++) {
                        Console.Write("*");
                    }
                }

                catch
                { Console.WriteLine($"Failed to write stars..."); } // In case something goes wrong

                finally
                {
                    // Show the user the progressCounter value as well. And end the line with a OS-safe newline.
                    Console.Write($"  {Program.progressCounter}" + Environment.NewLine);
                    //Console.WriteLine(Environment.NewLine);
                    // Release the locking mechanism
                    Monitor.Exit(Program._lockingMechanism);
                    // Sleep 1 sec
                    Thread.Sleep(1000);
                }
            }
        }
        static void WriteHashtags(object callback)
        {
            // Set an exit condition for the loop
            while (Program.progressCounter <= 6000)
            {
                try
                {
                    // Enter a Monitor state on the lockingMechanism(_lock)
                    Monitor.Enter(Program._lockingMechanism);
                    // Increase the shared resource counter by $amountOfChars.
                    Program.progressCounter = Program.progressCounter + Program.amountOfChars;
                    // Loop the amount of chars, and write a star for each
                    for (int i = 0; i < Program.amountOfChars; i++)
                    {
                        Console.Write("#");
                    }
                }

                catch
                { Console.WriteLine($"Failed to write stars..."); } // In case something goes wrong

                finally
                {
                    // Show the user the progressCounter value as well. And end the line with a OS-safe newline.
                    Console.Write($"  {Program.progressCounter}" + Environment.NewLine);
                    // Release the locking mechanism
                    Monitor.Exit(Program._lockingMechanism);
                    // Sleep 1 sec
                    Thread.Sleep(1000);
                }
            }
        }
    }
    #endregion

}
