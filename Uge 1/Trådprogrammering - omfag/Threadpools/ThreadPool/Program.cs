using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Net;

namespace ThreadPooling
{
    #region Opgave 0
    /*
    using System;
    using System.Threading; // <-- Er af særlig interesse. Den sørger for at vi kan benytte frameworkets threading-funktionalitet
    class ThreadPoolDemo
    {
        // En worker thread, bemærk den tager en parameter af typen Object(hvilket er en superklasse for variabler)
        public void task1(object obj)
        {
            // Loop 2 gange
            for (int i = 0; i <= 2; i++)
            {
                // Skriv en besked hver gang loopet kører en omgang
                Console.WriteLine("Task 1 is being executed");
            }
        }
        public void task2(object obj)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 2 is being executed");
            }
        }

        static void Main()
        {
            // Opretter et objekt udfra klassen ThreadPoolDemo
            ThreadPoolDemo tpd = new ThreadPoolDemo();
            // Loop 2 gange
            for (int i = 0; i < 2; i++)
            {
                // Smider to jobs i threadpoolens kø, hver gang loopet kører.
                // Bemærk, at der oprettes et calback, så threadpoolen ved hvilken metode der skal eksekveres på tråden
                ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1));
                ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task2));
            }

            Console.Read();
        }
    }
    */
    #endregion

    #region Opgave 1
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
            Console.ReadKey();
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        static void Process(object callback)
        {
        }
    }
    */
    #endregion
    #region Opgave 1: Besvarelse
    /*
     * Skal metoden Process() tage et object som argument, begrund dit svar?
     * Ja det skal den. Men man behøver ikke bruge objektet til noget.
     * Det er således, by-design. 
     */
    #endregion

    #region Opgave 2
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
            Console.ReadKey();
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        static void Process(object callback)
        {
        }
    }
    */
    #endregion
    #region Opgave 2 - Udvidelse #1
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
            Console.ReadKey();
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        static void Process(object callback)
        {
            // for (int i = 0; i < 100000; i++)  {  } // Eksekveringstiden er en anelse længere
        }
    }
    */
    #endregion
    #region Opgave 2 - Udvidelse #2
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
            Console.ReadKey();
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        static void Process(object callback)
        {
            // for (int i = 0; i < 100000; i++) { for (int j = 0; j < 100000; j++) { } }
        }
    }
    */
    #endregion

    #region Opgave 3

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
            Console.ReadKey();
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        static void Process(object callback)
        {
            // Convert booleans to "Yes"/"No" strings
            string boolYesNo(bool unit) {
                if (unit == true) { return "Yes"; }
                else { return "No";  }
            }
            // Output requirements
            Console.WriteLine("Is the thread alive:" + boolYesNo(Thread.CurrentThread.IsAlive));
            Console.WriteLine("Is the thread running in the background: " + boolYesNo(Thread.CurrentThread.IsBackground));
            Console.WriteLine("Which priority does the thread have: " + Thread.CurrentThread.Priority.ToString());
        }

    }
    #endregion
    #region Opgave 3 - Besvarelse
    /*
        Start()   - Starter tråden
        Sleep()   - Pauser tråden i x antal tid
        Suspend() - Pauser tråden indtil den resumes - Er markeret obsolete, og anbefales ikke længere.
        Resume()  - Sætter en pauset tråd igang igen - Er markeret obsolete, og anbefales ikke længere.
        Abort()   - Dropper tråden og smider den til garbage collectoren
        Join()    - Hovedtråden vil afvente at den pågældende tråd kører færdigt, før hovedtråden fortsætter afvikling af sin programkode.
    */
    #endregion
}
