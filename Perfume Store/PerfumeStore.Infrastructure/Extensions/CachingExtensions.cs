using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerfumeStore.Application.Common.Interfaces;
using PerfumeStore.Infrastructure.Services;

namespace PerfumeStore.Infrastructure.Extensions;

internal static class CachingExtensions
{
    internal static IServiceCollection AddCaching(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = config.GetConnectionString("Redis");
            options.InstanceName = "PerfumeStore:";
        });

        services.AddScoped<ICacheService, RedisCacheService>();

        return services;
    }
}