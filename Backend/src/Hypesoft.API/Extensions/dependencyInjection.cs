using Hypesoft.Domain.Interfaces;
using Hypesoft.Infrastructure.Context;
using Hypesoft.Infrastructure.Repositories;
using Hypesoft.Application.UseCase;
using Hypesoft.Application.Validators;


namespace Hypesoft.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        services.AddSingleton<MongoContext>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<GetAllProductsUseCase>();
        services.AddScoped<CreateProductUseCase>();
        services.AddScoped<UpdateProductNameUseCase>();
        services.AddScoped<UpdateProductPriceUseCase>();
        services.AddScoped<UpdateProductDescriptionUseCase>();
        services.AddScoped<UpdateProductCategoryUseCase>();
        services.AddScoped<UpdateProductStockQuantityUseCase>();

        services.AddScoped<CreateProductValidator>();
        services.AddScoped<UpdateProductNameValidator>();
        services.AddScoped<UpdateProductPriceValidator>();
        services.AddScoped<UpdateProductDescriptionValidator>();
        services.AddScoped<UpdateProductCategoryValidator>();
        services.AddScoped<UpdateProductStockQuantityValidator>();

        return services;
    }
}