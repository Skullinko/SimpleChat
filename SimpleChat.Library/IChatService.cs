using System.Collections.Generic;
using System.ServiceModel;

namespace SimpleChat.Library
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        List<Message> GetMessages();

        [OperationContract]
        void SendMessage(Message message);
    }
}
