using NetApp;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetAppClient
{
    internal class Program
    {
        private static string ip = "127.0.0.1";
        private static UdpClient udpClient = new UdpClient();
        private static IPEndPoint iPEndPoin = new IPEndPoint(IPAddress.Parse(ip), 12345);

        static async Task Main(string[] args)
        {
            await SendMessage("Artem");
        }

        private static async Task ReceiveMessageAsync()
        {
            var buffer = await udpClient.ReceiveAsync();
            iPEndPoin = (IPEndPoint)buffer.RemoteEndPoint;
            string answer = Encoding.UTF8.GetString(buffer.Buffer);
            MessageServer msgServer = MessageServer.DeserializeFromJson(answer);
            if (msgServer.Status == false)
            {
                Console.WriteLine(msgServer.Text);
                Console.WriteLine("Сервер завершил свою работу. Нажмите любую клавишу для завершения работы клиента");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(msgServer.Text);

            }
        }

        public static async Task SendMessage(string from)
        {
            while (true)
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
                await udpClient.SendAsync(data, data.Length, iPEndPoin);

                await Task.Run(ReceiveMessageAsync);

            }
        }
    }
}
