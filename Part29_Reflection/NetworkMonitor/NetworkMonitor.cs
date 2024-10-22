using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Part29_Reflection.NetworkMonitor
{
    public static class NetworkMonitor
    {
        private static NetworkMonitorSettings _networkMonitorSettings = new NetworkMonitorSettings();
        private static Type? _warningServiceType;
        private static List<object> _listParamsValue = new List<object>();
        private static object? _newInstance;
        

        public static void Warning()
        {
            if (_newInstance is null)
            {
                _newInstance = Activator.CreateInstance(_warningServiceType);
            }
            var method = _warningServiceType?.GetMethod(_networkMonitorSettings.MethodToExecute);

            method?.Invoke(_newInstance, _listParamsValue.ToArray());
        }

        public static void BootstrapFromConfiguration(string dllPath)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            configuration.Bind("NetworkMonitorSettings", _networkMonitorSettings);

            //inspect the assemblu to check whether the correct types are contained within
            var assemb = Assembly.LoadFrom(dllPath);
            _warningServiceType = assemb.GetType(
                _networkMonitorSettings.WarningService);
            if (_warningServiceType is null)
            {
                throw new Exception("Configuration is invalid - warning service not found");
            }

            //inspect method
            var method = _warningServiceType.GetMethod(_networkMonitorSettings.MethodToExecute);
            if (method is null)
            {
                throw new Exception("Configuration is invalid - METHOD in warning service not found");
            }

            //inspect Properties
            var properties = method.GetParameters();
            foreach (var prop in properties)
            {
                if (!_networkMonitorSettings.PropertyBag.TryGetValue(prop.Name, out object outValued))
                {

                    throw new Exception("Configuration is invalid - Properties in warning service not found");
                }
                _listParamsValue.Add(outValued);
            }
            
        }
    }
}
