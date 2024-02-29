
namespace HjaelpJakob
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IProvider> providers = new List<IProvider>() {
                new VMessageProvider(){ProviderName = "VMessage", MessageCarrier = MessageCarrier.VMessage },
                new SMTPProvider(){ProviderName = "One.com_SMTP", MessageCarrier = MessageCarrier.Smtp }
            };


            IMessage message = new Message(MessageCarrier.Smtp, "ToSomeone@TheInternet.com", "Me@me.dk", "HelpingJakob", "This is a test message", "HTML");
            // Send to a single recipient
            MessageHandler.ProcessMessage(message, providers, false);

            // Send to multiple recipients
            message.Cc = ["John@doe.com", "Jane@doe.com","angela@merkel.de"]; // Add more recipients here
            MessageHandler.ProcessMessage(message, providers, true); // => Gets sent to the message handler for processing
        }
    }
}



