using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {

        var serverSocket = new Socket(SocketConstants.Constants.LOCAL_ENDPOINT.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        serverSocket.Bind(SocketConstants.Constants.LOCAL_ENDPOINT);
        serverSocket.Listen(100); // 100 is the maximum length of the pending connections queue

        Console.WriteLine($"Server started at {SocketConstants.Constants.LOCAL_ENDPOINT.Address}:{SocketConstants.Constants.LOCAL_ENDPOINT.Port}");

        while (true)
        {
            var clientSocket = await serverSocket.AcceptAsync();
            _ = ProcessClientAsyncAsMicrosoftRecomment(clientSocket);
        }
    }

    private static async Task ProcessClientAsyncAsMicrosoftRecomment(Socket clientSocket)
    {
        // Receive message.
        var buffer = new byte[1_024];
        while (true)
        {
            var received = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, received);
            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine($"Client [{clientSocket.RemoteEndPoint.ToString()}] : SIGN OUT. GOOD BYEEEEE");
                SendingNoMessage(clientSocket);
                break;
            }

            Console.Write($"Client [{clientSocket.RemoteEndPoint.ToString()}] : {response}");


            var ackMessage = "<|ACK|>";
            var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
            await clientSocket.SendAsync(echoBytes, SocketFlags.None);
            Console.Write(
                $" - Received {Environment.NewLine}");
        }


        Console.WriteLine("End of Process Client");
        //while (true)
        //{
        //    // Receive message.
        //    var buffer = new byte[1_024];
        //    var received = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);
        //    var response = Encoding.UTF8.GetString(buffer, 0, received);

        //    var eom = "<|EOM|>";
        //    if (response.IndexOf(eom) > -1 /* is end of message */)
        //    {
        //        Console.WriteLine(
        //            $"Socket server received message: \"{response.Replace(eom, "")}\"");

        //        var ackMessage = "<|ACK|>";
        //        var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
        //        await clientSocket.SendAsync(echoBytes, 0);
        //        Console.WriteLine(
        //            $"Socket server sent acknowledgment: \"{ackMessage}\"");

        //        break;
        //    }
        //    // Sample output:
        //    //    Socket server received message: "Hi friends 👋!"
        //    //    Socket server sent acknowledgment: "<|ACK|>"
        //}
    }

    private static void SendingNoMessage(Socket clientSocket)
    {
        clientSocket.Close();
        Console.WriteLine("Close Client Socket.....");
    }

    private static async Task ProcessClientAsync(Socket clientSocket)
    {
        try
        {
            using (clientSocket)
            {
                byte[] buffer = new byte[4096];

                while (true)
                {
                    int bytesRead = await clientSocket.ReceiveAsync(
                        new ArraySegment<byte>(buffer), SocketFlags.None);

                    if (bytesRead == 0) break; // Client disconnected

                    // Echo the data back to client
                    await clientSocket.SendAsync(
                        new ArraySegment<byte>(buffer, 0, bytesRead), SocketFlags.None);


                }

                clientSocket.Shutdown(SocketShutdown.Both);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing client: {ex.Message}");
        }
    }
}