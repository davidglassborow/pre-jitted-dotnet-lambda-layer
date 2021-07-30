using Microsoft.Extensions.DependencyInjection;
using Sample.Lambda.Interfaces;

namespace Sample.Lambda
{
    public static class Bootstrapper
    {
        public static ServiceProvider Boostrap(this IServiceCollection services)
        {
            services.AddSingleton<IHandler, Handler>();
            
            return services.BuildServiceProvider();
        }
    }
}