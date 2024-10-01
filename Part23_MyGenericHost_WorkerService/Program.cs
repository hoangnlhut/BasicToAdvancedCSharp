
namespace Part23_MyGenericHost_WorkerService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            //host.Run();
            await host.RunAsync();
        }
    }
}