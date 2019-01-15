using System.ServiceModel;
using System.Text;
using SimpleChat.Library;

namespace SimpleChat.Client.GUI
{
    class Client
    {
        private readonly IChatService _chatService;

        public string UserName { get; }

        public Client(string userName)
        {
            var channelFactory = new ChannelFactory<IChatService>("MyNetNamedTcpEndpoint");
            _chatService = channelFactory.CreateChannel();

            UserName = userName;
        }

        public void SendMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                _chatService.SendMessage(new Message(UserName, message));
        }

        public string GetMessages()
        {
            var result = new StringBuilder();

            foreach (var message in _chatService.GetMessages())
                result.Append($"{message}\n");

            return result.ToString();
        }
    }
}
