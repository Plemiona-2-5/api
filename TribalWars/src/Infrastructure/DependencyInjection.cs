using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Identity;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using Infrastructure.Repository;
using ApplicationCore.Services;

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
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IBuildingRequiredRepository, BuildingRequiredRepository>();
            services.AddScoped<IBuildingRequiredService, BuildingRequiredService>();

            services.AddScoped<IVillageBuildingRepository, VillageBuildingRepository>();

            services.AddScoped<IVillageMaterialRepository, VillageMaterialRepository>();

            return services;
        }
    }
}