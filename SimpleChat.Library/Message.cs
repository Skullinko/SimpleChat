using System;
using System.Runtime.Serialization;

namespace SimpleChat.Library
{
    [DataContract]
    public class Message
    {
        public int Id { get; set; }

        [DataMember]
        public DateTime Time { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Text { get; set; }

        public Message()
        {
        }

        public Message(string username, string text)
        {
            Time = DateTime.Now;
            UserName = username;
            Text = text;
        }

        public override string ToString()
        {
            return $"{Time:yyyy-MM-dd HH:mm:ss} {UserName}: {Text}";
        }
    }
}
