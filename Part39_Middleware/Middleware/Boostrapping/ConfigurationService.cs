using Middleware.Middeware;

namespace Middleware.Boostrapping
{
    public static class ConfigurationService
    {
        public static IApplicationBuilder UseMiddlewareCustom(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Middleware1>();
            builder.UseMiddleware<Middleware2>();
            builder.UseMiddleware<Middleware3>();
            builder.UseMiddleware<Middleware4>();
            builder.UseMiddleware<Middleware5>();
            return builder;
        }
    }
}
