using System.Net.Sockets;
using System.Net;
using System.Text;
using Chat;

namespace ChatServer
{
    public class Program
    {
        private static UdpClient udpClient = new UdpClient(Server.Port);
        private static IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private static CancellationToken token = cancelTokenSource.Token;
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Старт \"{Server.Name}\" (версия {Server.Version}) ({Server.Ip}:{Server.Port})");

            await Task.Run(ReceiveMessageAsync, token);
        }

        private static async Task ReceiveMessageAsync()
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Сервер не доступен");
                    return;
                }
                var receiver = await udpClient.ReceiveAsync();
                iPEndPoint = (IPEndPoint)receiver.RemoteEndPoint;
                var messageText = Encoding.UTF8.GetString(receiver.Buffer);
                Message message = Message.DeserializeFromJson(messageText);
                message.Print();

                //if (message.Text == "exit")
                //{
                //    cancelTokenSource.Cancel();
                //    await SendMessageAsync("Сервер не доступен", false);
                //}

                //await SendMessageAsync("Сообщение доставлено");
            }
        }
    }
}
