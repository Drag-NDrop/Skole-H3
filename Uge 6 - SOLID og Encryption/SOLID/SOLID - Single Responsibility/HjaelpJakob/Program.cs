
namespace HjaelpJakob
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IProvider> providers = new List<IProvider>() {
                new VMessageProvider(),
                new SMTPProvider()
            };


            Message message = new Message(MessageCarrier.VMessage,"ToSomeone@TheInternet.com","Me@me.dk","HelpingJakob","This is a test message","someone@else.com");
            MessageHandler messageHandler = new MessageHandler(message, providers );

            messageHandler.SendMessageToAll(message.To, message, true);

        }
    }
}



