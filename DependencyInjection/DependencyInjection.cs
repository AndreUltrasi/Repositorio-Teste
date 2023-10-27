using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Repository.Interfaces;
using WebApplication2.Repository;

public static class DependencyInjection
{
    public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration)
    {
        string sqlConnectionString = configuration.GetConnectionString("SqlDatabase")!;

        services.AddDbContext<DataContext>(x => x.UseSqlServer(sqlConnectionString));
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductsRepository, ProductsRepository>(); // injeção de dependencia

        return services;
    }
}