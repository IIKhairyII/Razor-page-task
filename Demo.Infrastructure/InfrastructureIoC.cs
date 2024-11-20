using Demo.Application.Repositories;
using Demo.Application.Services;
using Demo.Infrastructure.Repositories;
using Demo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure
{
    public static class InfrastructureIoC
    {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
