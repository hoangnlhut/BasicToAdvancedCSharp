using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Part26Configurations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region using basic configuration of ConfigurationBuilder
            //BasicConfigurationUsingEnvAndJsonProviders();
            #endregion

            #region using configuration with hosting
            //BasicConfigurationWithHosting();
            #endregion

            #region using configuration with Options pattern
            BasicConfigurationWithOptionPattern();
            #endregion
        }

        private static async void BasicConfigurationWithOptionPattern()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();

            builder.Configuration.Sources.Clear();

            IHostEnvironment env = builder.Environment;

            builder.Configuration
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

            TransientFaultHandlingOptions options = new();
            builder.Configuration.GetSection(nameof(TransientFaultHandlingOptions))
                .Bind(options);

            Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
            Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");

            using IHost host = builder.Build();

            // Application code should start here.

            await host.RunAsync();
        }

        private static void BasicConfigurationWithHosting()
        {

            using IHost host = Host.CreateApplicationBuilder().Build();

            // ask the service provider for the configuration abstraction
            IConfiguration configuration = host.Services.GetRequiredService<IConfiguration>();

            #region FIRST WAY TO GET VALUE
            // Get values from the config given their key and their target type
            int keyOneValue = configuration.GetValue<int>("Settings:KeyOne");
            bool keyTwoValue = configuration.GetValue<bool>("Settings:KeyTwo");
            string keyThreeValue = configuration.GetValue<string>("Settings:KeyThree:Message");

            // Write the values to the console.
            Console.WriteLine($"KeyOne = {keyOneValue}");
            Console.WriteLine($"KeyTwo = {keyTwoValue}");
            Console.WriteLine($"KeyThree:Message = {keyThreeValue}");
            #endregion

            #region SECOND WAY TO GET VALUE
            // Get values from the config given their key and their target type.
            string? ipOne = configuration["Settings:IPAddressRange:0"];
            string? ipTwo = configuration["Settings:IPAddressRange:1"];
            string? ipThree = configuration["Settings:IPAddressRange:2"];
            string? versionOne = configuration["Settings:KeyThree:SupportedVersions:v1"];
            string? versionThree = configuration["Settings:KeyThree:SupportedVersions:v3"];

            // Write the values to the console.
            Console.WriteLine($"IPAddressRange:0 = {ipOne}");
            Console.WriteLine($"IPAddressRange:1 = {ipTwo}");
            Console.WriteLine($"IPAddressRange:2 = {ipThree}");
            Console.WriteLine($"SupportedVersions:v1 = {versionOne}");
            Console.WriteLine($"SupportedVersions:v3 = {versionThree}");
            #endregion
        }

        private static void BasicConfigurationUsingEnvAndJsonProviders()
        {
            // Build a config object, using env vars and JSON providers.
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            //Binding Get values from the config given their key and thei target type
            Settings? settings = configuration.GetRequiredSection("Settings").Get<Settings>();

            // Write the values to the console.
            Console.WriteLine($"KeyOne = {settings?.KeyOne}");
            Console.WriteLine($"KeyTwo = {settings?.KeyTwo}");
            Console.WriteLine($"KeyThree:Message = {settings?.KeyThree?.Message}");
            Console.WriteLine($"KeyThree:SupportedVersions:v1 = {settings?.KeyThree?.SupportedVersions?.v1}");
            Console.WriteLine($"KeyThree:SupportedVersions:v3 = {settings?.KeyThree?.SupportedVersions?.v3}");

            foreach ( var ip in settings?.IPAddressRange ) {
                Console.WriteLine($"IPAddressRange = {ip}");
            }
            
        }
    }
}
