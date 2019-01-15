using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SimpleChat.Database.Model;
using SimpleChat.Library;
using Message = SimpleChat.Library.Message;

namespace SimpleChat.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        //private readonly List<Message> _messages = new List<Message>();

        public List<Message> GetMessages()
        {
            //return _messages;

            using (var context = new MessageContext())
            {
                return context.Messages.ToList();
            }
        }

        public async void SendMessage(Message message)
        {
            //_messages.Add(message);

            // Ak je viac ako 10 sprav, odstran stare spravy
            //while (_messages.Count > 10)
            //    _messages.RemoveAt(0);

            using (var context = new MessageContext())
            {
                context.Messages.Add(message);
                await context.SaveChangesAsync();
            }
        }
    }

}
