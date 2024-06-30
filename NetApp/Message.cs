using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetApp
{
    public enum Commands
    {
        Register,
        Delete
    }

    public class Message
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string NicknameFrom { get; set; }
        public string NicknameTo { get; set; }
        public Commands command {get;set;}


        

        public string SerializeMessegeToJson() => JsonSerializer.Serialize(this);
        public static Message? DeserializeFromJson(string message) => JsonSerializer.Deserialize<Message>(message);

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{this.DateTime}: Получено сообщение от {this.NicknameFrom}: {this.Text}";
        }

    }
}
