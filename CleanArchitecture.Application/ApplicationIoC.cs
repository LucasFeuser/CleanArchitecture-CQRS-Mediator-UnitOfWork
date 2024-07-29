using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class ApplicationIoC
{
    public static void ResolveApplication(this IServiceCollection services)
    {
        AssemblyScanner
            .FindValidatorsInAssembly(Assembly.GetAssembly(typeof(ApplicationIoC)))
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

    }
}