using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sample.Lambda.Interfaces;

namespace Sample.Lambda
{
    public static class Bootstrapper
    {
        public static ServiceProvider Boostrap(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton(s => s.GetRequiredService<ILoggerFactory>().CreateLogger(""));
            services.AddSingleton<IHandler, Handler>();
            
            return services.BuildServiceProvider();
        }
    }
}