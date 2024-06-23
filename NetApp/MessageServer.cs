using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetApp
{
    public class MessageServer
    {
        public string Text { get; set; }
        public bool Status { get; set; }
        public string SerializeMessegeToJson() => JsonSerializer.Serialize(this);
        public static MessageServer? DeserializeFromJson(string message) => JsonSerializer.Deserialize<MessageServer>(message);
    }
}
