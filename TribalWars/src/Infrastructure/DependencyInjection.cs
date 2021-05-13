using System.Reflection;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Identity;
using ApplicationCore.Interfaces;
using Infrastructure.Repository;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IBuildingRequiredRepository, BuildingRequiredRepository>();
            services.AddScoped<IBuildingRequiredService, BuildingRequiredService>();

            services.AddScoped<IVillageBuildingRepository, VillageBuildingRepository>();

            services.AddScoped<IVillageMaterialRepository, VillageMaterialRepository>();

            return services;
        }
    }
}