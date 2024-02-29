namespace HjaelpJakob
{
    public interface IProvider
    {

        public string ProviderName { get; set; }
        public MessageCarrier MessageCarrier { get; set; }

        public bool SendMessage(IMessage m);

        public bool sendMessageToAll(IMessage m);
    }
}
