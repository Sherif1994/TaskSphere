using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace TaskSphere.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Add FluentValidation or any other services here later
            return services;
        }
    }
}
