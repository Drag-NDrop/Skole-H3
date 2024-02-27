/*
 * C# Program to Create a Simple Thread
 */
using System;
using System.Runtime.CompilerServices;
using System.Threading;
class program
{
    #region Opgave 4 : Variabler
    private char sharedCharacter = '*';
    private object lockObject = new object();
    #endregion
    #region Opgave 1
    /// <summary>
    ///  Tæller til 5, for hver iteration, udskriver den "SimpleThread"
    /// </summary>
    public void WorkThreadFunction()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Programmering er nemt!");
        }
    }

    #endregion
    #region Opgave 2
    public void WorkThreadEzpz()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Også med flere tråde!");
            Thread.Sleep(1000);
        } 
    }
    #endregion
    #region Opgave 3
    public void WorkThreadTemp()
    {
        int alarmcount = 0;
        Random rnd = new Random();
        while (alarmcount != 3) { 
            int temp = rnd.Next(-20, 120);
            if (temp > 100 || 0 > temp)
            {
                Console.WriteLine("Error... " + "Temp: " + temp.ToString());
                alarmcount++;
            }
            else
            {
                Console.WriteLine("Temp:" + temp.ToString());
            }
            if (alarmcount == 3) {
                Console.WriteLine("Temp thread: terminated...");
            }
            Thread.Sleep(2000);
        }
}

    #endregion
    #region Opgave 4
    public void WorkThreadWriter()
    {
        while (true)
        {
            Monitor.Enter(this.lockObject);
            try { 
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(this.sharedCharacter);
                }
            }
            finally { Monitor.Exit(this.lockObject);}
        }
    }

    public void WorkThreadReader() {
        char characterToSend = '*';
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Monitor.Enter(this.lockObject);
            try
            {
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        Console.WriteLine("You pressed Escape. Program exiting..!");
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.Enter:
                        sharedCharacter = characterToSend;
                        break;
                        // Add more cases for other keys as needed
                    default:
                        characterToSend = key.KeyChar;
                      //  Console.WriteLine("You pressed: " + sharedCharacter);
                        break;
                }
            }
            finally
            {
                Monitor.Exit(this.lockObject);
            }
        }

    }
    #endregion
}

class threprog
    {
        public static void Main()
        {
            // Opretter et objekt fra program klassen. 
            program pg = new program();
        #region Opgave 1
        // Det giver os en klasse, der indeholder en tråd, der udfører WorkThreadFunction, hver gang den køres.
        // Opgave 1:
        /*
        // Definerer en tråd, ved at instaniere et objekt fra ThreadStart-klassen, som får WorkThreadFunction koden.
            Thread thread = new Thread(new ThreadStart(pg.WorkThreadFunction));

            // Starter trådene    
            thread.Start();
        */
        #endregion
        #region Opgave 2
        // Opgave 2:
        /*
            Thread thread2 = new Thread(new ThreadStart(pg.WorkThreadEzpz));
            thread2.Start();
        */
        #endregion
        #region Opgave 3
        // Opgave 3
        /*
            Thread thread3 = new Thread(new ThreadStart(pg.WorkThreadTemp));
            thread3.Start();            


        // Opgave 3
        while (true) {

            if (thread3.ThreadState == ThreadState.Stopped)
            {
                Console.WriteLine("Main Thread: Temp thread terminated!");
                Console.WriteLine("Press ENTER to exit.");
                Console.Read();
                Environment.Exit(0);

            }
            else {
                Console.WriteLine("Sleeping 10s");
                Thread.Sleep(10000);
            }
        }
*/
        #endregion
        #region Opgave 4
            Thread readerThread = new Thread(new ThreadStart(pg.WorkThreadReader));
            readerThread.Start();

            Thread writerThread = new Thread(new ThreadStart(pg.WorkThreadWriter));
            writerThread.Start();
        #endregion
    }

}

