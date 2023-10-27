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
    }
}
