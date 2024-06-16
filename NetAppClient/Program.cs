using NetApp;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetAppClient
{
    internal class Program
    {
        static void Main(string[] args)
        {       
            //for (int i = 0; i < 10; i++)
            //{
            SendMessage("Artem");

            //}
        }

        public static void SendMessage(string from, string ip="127.0.0.1")
        {
            

            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoin = new IPEndPoint(IPAddress.Parse(ip), 12345);
            string answer = "Сообщение доставлено";

            
            while (answer == "Сообщение доставлено")
            {
                string messageText;
                do
                {
                    //Console.Clear();
                    Console.Write("Введите сообщение: ");
                    messageText = Console.ReadLine();
                }

                while (string.IsNullOrEmpty(messageText));
                Message message = new Message() { DateTime = DateTime.Now, NicknameFrom = from, NicknameTo = "Anna", Text = messageText };
                string json = message.SerializeMessegeToJson();

                byte[] data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data,data.Length, iPEndPoin);

                
                byte[] buffer = udpClient.Receive(ref iPEndPoin);
                answer = Encoding.UTF8.GetString(buffer);
               
                    Console.WriteLine(answer);               
            }
            Console.WriteLine("Сервер завершил свою работу. Нажмите любую клавишу для завершения работы клиента");
            Console.ReadKey();
        }
    }
}
