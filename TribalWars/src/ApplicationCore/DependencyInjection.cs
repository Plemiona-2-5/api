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
            services.AddTransient<IJwtService, JwtService>();

            services.AddScoped<IBuildingsQueueService, BuildingsQueueService>();

            services.AddScoped<ITribeService, TribeService>();

            services.AddScoped<IRecruitmentQueueService, RecruitmentQueueService>();
          
            services.AddScoped<ITribeMemberService, TribeMemberService>();

            services.AddScoped<IVillageMaterialServices, VillageMaterialServices>();

            return services;
        }
    }
}