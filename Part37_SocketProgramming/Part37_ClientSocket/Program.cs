using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Part37_ClientSocket
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            using Socket client = new(SocketConstants.Constants.LOCAL_ENDPOINT.AddressFamily,SocketType.Stream,ProtocolType.Tcp);

            await client.ConnectAsync(SocketConstants.Constants.LOCAL_ENDPOINT);
            
            
            Console.WriteLine($"Welcome Client {client.LocalEndPoint?.ToString() ?? "Unknown"}");
            //sending mesaage to server
            while (true)
            {
                Console.Write($"Message: ");
                var message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                {
                    Console.WriteLine("GOOD BYE!!!!!");
                    break;
                }

                var messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await client.SendAsync(messageBytes, SocketFlags.None);

                //Receive ack.
                var buffer = new byte[1_024];
                var received = await client.ReceiveAsync(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    Console.Write(
                        $"Sent {Environment.NewLine}");
                }
            }

            //while (true)
            //{
            //    // Send message.
            //    var message = "Hi friends 👋!<|EOM|>";
            //    var messageBytes = Encoding.UTF8.GetBytes(message);
            //    _ = await client.SendAsync(messageBytes, SocketFlags.None);
            //    Console.WriteLine($"Socket client sent message: \"{message}\"");

            //    // Receive ack.
            //    //var buffer = new byte[1_024];
            //    //var received = await client.ReceiveAsync(buffer, SocketFlags.None);
            //    //var response = Encoding.UTF8.GetString(buffer, 0, received);
            //    //if (response == "<|ACK|>")
            //    //{
            //    //    Console.WriteLine(
            //    //        $"Socket client received acknowledgment: \"{response}\"");
            //    //    break;
            //    //}

            //}

            client.Shutdown(SocketShutdown.Both);
        }

       
    }
}
