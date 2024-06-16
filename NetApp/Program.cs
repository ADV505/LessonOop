using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Server();
        }

        public static void Server()
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Сервер ждет сообщение от клиента...");

            while (true)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                var messageText = Encoding.UTF8.GetString(buffer);

                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Message message = Message.DeserializeFromJson(messageText);
                    message.Print();
                    if (message.Text.ToString().ToLower() == "exit")
                    {
                        byte[] answer = Encoding.UTF8.GetBytes("Сервер ушел в аут");
                        udpClient.Send(answer,answer.Length,iPEndPoint);

                        Environment.Exit(0);
                    }
                    else
                    {
                        byte[] answer = Encoding.UTF8.GetBytes("Сообщение доставлено");
                        udpClient.Send(answer, answer.Length, iPEndPoint);
                    }

                });
            }
        }
    }
}
