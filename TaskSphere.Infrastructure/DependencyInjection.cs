using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskSphere.Infrastructure.Persistence;

namespace TaskSphere.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                  ?? "Data Source=tasksphere.db"; // fallback SQLite

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

            // Register repositories, identity, etc. later
            return services;
        }
    }
}
