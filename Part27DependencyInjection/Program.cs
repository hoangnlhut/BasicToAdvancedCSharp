using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Part27DependencyInjection.StandardDI;

namespace Part27DependencyInjection
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            #region Hoang example
            //HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            //builder.Services.AddSingleton<IMessageWriter, MessageWriter>();

            //using IHost host = builder.Build();

            //Class1 class1 = new(new MessageWriter());
            //class1.PrintMessageWriter();

            //host.Run();
            #endregion

            #region Sample standard example
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddTransient<IExampleTransientService, ExampleTransientService>();
            builder.Services.AddScoped<IExampleScopedService, ExampleScopedService>();
            builder.Services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
            builder.Services.AddTransient<ServiceLifetimeReporter>();

            using IHost host = builder.Build();

            ExemplifyServiceLifetime(host.Services, "Lifetime 1");
            ExemplifyServiceLifetime(host.Services, "Lifetime 2");

            await host.RunAsync();

            static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
            {
                using IServiceScope serviceScope = hostProvider.CreateScope();
                IServiceProvider provider = serviceScope.ServiceProvider;
                ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
                logger.ReportServiceLifetimeDetails(
                    $"{lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()");

                Console.WriteLine("...");

                logger = provider.GetRequiredService<ServiceLifetimeReporter>();
                logger.ReportServiceLifetimeDetails(
                    $"{lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()");

                Console.WriteLine();
            }
            #endregion

        }
    }
}
