﻿using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));



        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
        
        
        
        
        
        
        
        return services;
    }
}