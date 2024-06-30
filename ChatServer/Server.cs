using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public enum Status
    {
        Online,
        Offline
    }
    public class Server
    {
        public static string Name  => "UDP ChatServer"; 
        public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string Ip => "127.0.0.1";
        public static int Port => 12345;
        public static Status Status {  get; set; }

    }
}
