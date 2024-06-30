using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetApp
{
    public class Server
    {
        public string Name { get => "Server"; }
        public Dictionary<string, IPEndPoint> Users { get; private set; }

        public void Register(string name, IPEndPoint iPEndPoint)
        {
            if (Users == null)
                Users = new Dictionary<string, IPEndPoint>();
            Users.Add(name, iPEndPoint);
        }
        public void Delete(string name)
        {
            Users.Remove(name);
        }
    }
}
