using System.Data;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.CrossCutting.Common.CQRS.Validator;

namespace CleanArchitecture.CrossCutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMemberDappRepository, MemberDappRepository>();
            services.AddScoped<IMemberEfRepository, MemberEfRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString)));

            services.AddTransient<IDbConnection>(_ => new MySqlConnection(connectionString));

            services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("CleanArchitecture.Application"));
                    cfg.AddOpenBehavior(typeof(ValidatorBehaviour<,>));
                }
            );

            return services;
        }
    }
}