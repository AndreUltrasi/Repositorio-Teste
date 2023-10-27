using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Products> Products { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();
            var connectionString = configuration.GetConnectionString("SqlDatabase");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
