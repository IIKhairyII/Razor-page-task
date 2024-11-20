using Microsoft.Extensions.DependencyInjection;

namespace Demo.Application
{
    public static class ApplicationIoC
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationIoC).Assembly));
            return services;
        }
    }
}
