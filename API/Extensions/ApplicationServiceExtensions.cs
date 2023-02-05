using API.Data;
using API.Interface;
using API.Services;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration config)
        {
            // conection to the DB
            services.AddDbContext<DataContext>(opt=>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            // CORS
            services.AddCors();
            //token service- time scope
            services.AddScoped<ITokenService,TokenService>();
             return services;
        }
        
    }
