using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Application
{
    public static class ApplicationIoC
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationIoC).Assembly));
            services.AddValidatorsFromAssembly(typeof(ApplicationIoC).Assembly);
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}
