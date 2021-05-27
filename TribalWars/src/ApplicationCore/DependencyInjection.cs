using System.Reflection;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddTransient<IJwtService, JwtService>();

            services.AddScoped<IBuildingsQueueService, BuildingsQueueService>();

            services.AddScoped<ITribeService, TribeService>();

            services.AddScoped<IRecruitmentQueueService, RecruitmentQueueService>();
          
            services.AddScoped<ITribeMemberService, TribeMemberService>();

            services.AddScoped<IBuildingService, BuildingService>();

            services.AddScoped<IVillageMaterialService, VillageMaterialService>();

            return services;
        }
    }
}