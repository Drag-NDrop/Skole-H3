using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace DiningPhilosophers
{
    internal class Program
    {
        // To make the code a bit more fun to read - here's a fork.
        internal class Fork {
            // Non-blocking Synchronicity technique:
            // Implement the locking mechanism we will be using for thread-synchronization.
            // We do it like this, to ensure that the shared ressources always have a clear indicator, to show if they're available.
            internal object _available = new object(); // This is our lock-object
        }
        // Gather a bunch of forks.
        internal static List<Fork> Forks = new List<Fork>
       {
            new Fork(),
            new Fork(),
            new Fork(),
            new Fork(),
            new Fork()
       };
        
        internal class Philosopher
        {
            private int _id;
            private Fork _rightHand; // What.. never seen a philosopher with forks for hands?
            private Fork _leftHand;  // Yep.
            private Random _randomThought = new Random(); // All thoughts has a beginning and an end. We define them here, to avoid creating new objects during runtime.
            public Philosopher(int id, Fork leftHandFork, Fork rightHandFork)
            {
                // Constructor always prefills these three values.
                this._id = id;
                this._leftHand = leftHandFork;
                this._rightHand = rightHandFork;
            }

            internal void Ponder() {
                // Simulate a philisophical question that demands immediate pondering.
                int introspectrumTime = this._randomThought.Next(10,1000);
                Console.WriteLine($"💤 🕑 💤: Philosopher #{this._id} ponders existence.......");
                Console.WriteLine("------------------------------------------------------------");
                Thread.Sleep(introspectrumTime);
            }

            internal void GrabABite() {
                // We always look for the left fork first. If it's available, we'll grab it. If not, we will ponder.
                // Non-blocking Synchronicity technique:
                if (Monitor.TryEnter(_leftHand._available))
                {
                    try { 
                        // So far so good! The left fork is ours!! Now, we must try to grab the right-hand fork.
                        if (Monitor.TryEnter(_rightHand._available))
                        {
                            // Success!! Time to eat!
                            this.EatSpaghetti();
                            // Hurry, the other philosophers with forks for hands are dying from starvation. Put down the forks!
                            Monitor.Exit(_leftHand._available);
                            Monitor.Exit(_rightHand._available);
                        }
                        else { Monitor.Exit(_leftHand._available); }
                    }
                    catch { Console.WriteLine("🛑 : The adjacent philosopher stabs you!(There was an error"); } // I really wish it hadn't come to this.
                    finally
                    {
                        this.Ponder(); // Time to do what philosophers do best.
                    }
                }
                else {
                    this.Ponder(); // What went wrong? Would that have happened in another dimensions where philosophers didn't have forks for hands?
                }
            }

            internal void Dine(object callBack){ // A WHOLE METHOD?!, JUST TO RUN A LOOP?!... yes.           
                while (true) { this.GrabABite(); } // Nudge the philosopher to grab a bite of spaghetti.
            }

            internal void EatSpaghetti() {
                Console.WriteLine($"🍝 🍴 : Philosopher #{this._id} enjoyed a bit of spaghetti!");
                Console.WriteLine("------------------------------------------------------------");
            }
        }

        // Draw philosophers from an unknown realm. Where philosophers has forks for hands!
        internal static List<Philosopher> Philosophers = new List<Philosopher>{
            new Philosopher(1, Forks[0],Forks[1]), // To be or not to be.
            new Philosopher(2, Forks[1],Forks[2]), // No, Sam I am, i do not like green eggs and ham.
            new Philosopher(3, Forks[2],Forks[3]), // Thinking: The talking of the soul, with itself.
            new Philosopher(4, Forks[3],Forks[4]), // I think, therefore i am.
            new Philosopher(5, Forks[4],Forks[0])  // The only thing i know, is that i know nothing.
        };

        static void Main(string[] args)
        {
            foreach (Philosopher philosopher in Philosophers)
            {
                // The most important part of thread synchronicity: Threads to synchronize!
                ThreadPool.QueueUserWorkItem(new WaitCallback(philosopher.Dine));
            }
            // Keep going until i disturb your thougt-process.
            Console.ReadKey();
        }
    }
}
