using System.Net;

namespace SocketConstants
{
    public static class Constants
    {
        public const int PORT = 8899;
        public static readonly IPEndPoint LOCAL_ENDPOINT = new(IPAddress.Loopback, PORT);
    }
}
