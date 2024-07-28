using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.CrossCutting.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("CleanArchitecture.Application")));

        
        return services;
    }
}