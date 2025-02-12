using LogsData.Repository;
using LogsDomain.Interfaces;
using LogsInfraData.Context;
using LogsService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogsInfraCrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(ILogRepository<>), typeof(LogRepository<>));

            services.AddScoped(typeof(IBaseLogService<>), typeof(BaseService<>));

            return services;
        }
    }
}
