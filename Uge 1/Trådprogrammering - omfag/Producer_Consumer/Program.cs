namespace Producer_Consumer
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random random = new Random();
            #region Opgave 1: Uden wait og Pulse
            /* 
            BufferQueue buffer1 = new BufferQueue(1,true);

            Producer producer1 = new Producer(1, buffer1, 0, 10, random);
            Producer producer2 = new Producer(2, buffer1, 0, 10, random);
            Producer producer3 = new Producer(3, buffer1, 0, 10, random);
            Consumer consumer1 = new Consumer(1, buffer1, 1);
            Consumer consumer2 = new Consumer(2, buffer1, 1);
            Consumer consumer3 = new Consumer(3, buffer1, 1);
            */
            #endregion

            #region Opgave 2: Med wait og pulse
            BufferQueueWithPulse buffer1 = new BufferQueueWithPulse(1, true);
            ProducerWithPulse producer1 = new ProducerWithPulse(1, buffer1, 0, 10, random);
            ConsumerWithPulse consumer1 = new ConsumerWithPulse(1, buffer1, 1);
            producer1.StartProduce();
            consumer1.StartConsuming();
            #endregion
            Console.ReadKey();
        }
    }
}
