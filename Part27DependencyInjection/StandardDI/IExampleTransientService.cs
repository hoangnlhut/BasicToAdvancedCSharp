using Microsoft.Extensions.DependencyInjection;

namespace Part27DependencyInjection.StandardDI
{
    public interface IExampleTransientService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
