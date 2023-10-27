using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddAddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>(x => x.UseSqlite("DataSource=app.db;Cache=Shared"));
        return services;
    }
}