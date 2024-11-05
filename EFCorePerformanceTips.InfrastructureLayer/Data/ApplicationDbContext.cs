using EFCorePerformanceTips.CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCorePerformanceTips.InfrastructureLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly Lazy<string> _lazyConnectionString = new Lazy<string>(() =>
        {
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();
            return configuration.GetConnectionString("DefaultConnection") ?? "YourFallbackConnectionString";
        });

        public static string ConnectionString => _lazyConnectionString.Value;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
