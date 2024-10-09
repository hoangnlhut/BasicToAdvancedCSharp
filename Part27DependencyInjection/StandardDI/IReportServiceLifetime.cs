using Microsoft.Extensions.DependencyInjection;

namespace Part27DependencyInjection.StandardDI
{
    public interface IReportServiceLifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}
