using Hypesoft.Domain.Interfaces;
using Hypesoft.Infrastructure.Context;
using Hypesoft.Infrastructure.Repositories;
using Hypesoft.Application.UseCase;
using Microsoft.Extensions.DependencyInjection;
using Hypesoft.Application.Validators;


namespace Hypesoft.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        services.AddSingleton<MongoContext>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<CreateProductUseCase>();
        services.AddScoped<CreateProductValidator>();

        return services;
    }
}