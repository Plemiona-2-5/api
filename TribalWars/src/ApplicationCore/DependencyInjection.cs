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

            services.AddScoped<ITribeService, TribeService>();

            return services;
        }
    }
}