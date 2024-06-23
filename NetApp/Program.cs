using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetApp
{
    internal class Program
    {
        private static UdpClient udpClient = new UdpClient(12345);
        private static IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private static CancellationToken token = cancelTokenSource.Token;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Сервер ждет сообщение от клиента...");

            await Task.Run(ReceiveMessageAsync, token);
            
        }

        private static async Task SendMessageAsync(string notice, bool status = true)
        {
            MessageServer messageServer = new MessageServer() { Text = notice, Status = status};
            var answer = Encoding.UTF8.GetBytes(messageServer.SerializeMessegeToJson());
            await udpClient.SendAsync(answer, answer.Length, iPEndPoint);
        }

        static async Task ReceiveMessageAsync()
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

                if (message.Text == "exit")
                {
                    cancelTokenSource.Cancel();
                    await SendMessageAsync("Сервер не доступен", false);
                }

                await SendMessageAsync("Сообщение доставлено");
            }
        }
    }
}
