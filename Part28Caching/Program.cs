using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Part28Caching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddMemoryCache();
        }
    }
}
