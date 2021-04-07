using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalApplication.Core.Services.Interfaces;
using PortalApplication.Infrastructure.Logger;
using PortalApplication.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplication.Infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void ConfigureDBContextPool(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<ApplicationDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                optionBuilder.EnableSensitiveDataLogging();
            });
        }

        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            });
        }


        public static void ResolveInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.ConfigureDBContextPool(config);
           
            services.AddSingleton<IFileLogger, AppLoggerService>();
            services.AddScoped<IContactFormRepository, ContactFormRepository>();

        }

    }
}
