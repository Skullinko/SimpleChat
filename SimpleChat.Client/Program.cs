using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleChat.Library;

namespace SimpleChat.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var channelFactory = new ChannelFactory<IChatService>("MyNetNamedTcpEndpoint"))
            {
                IChatService client = channelFactory.CreateChannel();
                while (true)
                {
                    Console.Clear();

                    foreach (Message message in client.GetMessages())
                        Console.WriteLine(message);

                    Console.Write("Zadajte novú správu: ");
                    string text = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(text))
                        client.SendMessage(new Message("userName", text));
                }
            }
        }
    }
    
}
