using Microsoft.Extensions.DependencyInjection;

namespace Part27DependencyInjection.StandardDI
{
    public interface IExampleSingletonService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}
