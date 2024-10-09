using Microsoft.Extensions.DependencyInjection;

namespace Part27DependencyInjection.StandardDI
{
    public interface IExampleScopedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}
