
namespace Part23_MyGenericHost_WorkerService
{
    #region Worker service in the beginning when create this project
    public class WorkerOld : BackgroundService
    {
        private readonly ILogger<WorkerOld> _logger;
        private readonly IConfiguration _configuration;

        public WorkerOld(ILogger<WorkerOld> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    if (_logger.IsEnabled(LogLevel.Information))
            //    {
            //        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    }
            //    await Task.Delay(1000, stoppingToken);
            //}

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            _logger.LogInformation("Hello World");
            _logger.LogCritical("Hello World");
            _logger.LogDebug("Hello World");
            _logger.LogError("Hello World");
            _logger.LogWarning("Hello World");

            _logger.LogInformation($"Config : {_configuration.GetValue<string>("MySetting")}");

        }
    }
    #endregion

    public sealed class Worker : IHostedService, IHostedLifecycleService
    {
        private readonly ILogger _logger;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime appLifetime)
        {
            _logger = logger;

            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
        }

        Task IHostedLifecycleService.StartingAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1. StartingAsync has been called.");

            return Task.CompletedTask;
        }

        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("2. StartAsync has been called.");

            return Task.CompletedTask;
        }

        Task IHostedLifecycleService.StartedAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("3. StartedAsync has been called.");

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("4. OnStarted has been called.");
        }

        private void OnStopping()
        {
            _logger.LogInformation("5. OnStopping has been called.");
        }

        Task IHostedLifecycleService.StoppingAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("6. StoppingAsync has been called.");

            return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("7. StopAsync has been called.");

            return Task.CompletedTask;
        }

        Task IHostedLifecycleService.StoppedAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("8. StoppedAsync has been called.");

            return Task.CompletedTask;
        }

        private void OnStopped()
        {
            _logger.LogInformation("9. OnStopped has been called.");
        }
    }
}
