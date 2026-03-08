using Hypesoft.Domain.Interfaces;
using Hypesoft.Infrastructure.Context;
using Hypesoft.Infrastructure.Repositories;
using FluentValidation;



namespace Hypesoft.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        // Pegamos o Assembly da Application para o MediatR e FluentValidation buscarem as classes
        var applicationAssembly = AppDomain.CurrentDomain.Load("Hypesoft.Application");

        // 1. Infraestrutura
        services.AddSingleton<MongoContext>();
        services.AddScoped<IProductRepository, ProductRepository>();

        // 2. MediatR
        // Registra todos os Handlers automaticamente
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // 3. FluentValidation
        // Registra todos os AbstractValidator<T> de uma vez só!
        services.AddValidatorsFromAssembly(applicationAssembly);

        return services;
    }
}
