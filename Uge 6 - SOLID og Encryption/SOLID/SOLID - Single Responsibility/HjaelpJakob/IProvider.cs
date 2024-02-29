namespace HjaelpJakob
{
    public interface IProvider
    {

        public string ProviderName { get; set; }
        public MessageCarrier MessageCarrier { get; set; }

        public bool SendMessage(Message m, bool isHTML);

        public bool sendMessageToAll(string[] to, Message m, bool isHTML);
    }
}
