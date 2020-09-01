using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Entidades.Context;
using Microsoft.EntityFrameworkCore;
using Contracts.Services;
using Services.Wrapper;

namespace CorreiosTake.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection serviceCollection)
        {
            //serviceColleection.AddSingleton<ILoggerManager, LoggerManger>();
        }

        public static void ConfigureIIS(this IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<IISOptions>(option => { });
        }

        public static void ConfigureSQLServerContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<CorreiosContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureServiceWrapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IServiceWrapper, ServiceWrapper>();
        }
    }
}
