using Microsoft.EntityFrameworkCore;
using StoredProcedureDemo.WebApp.Configurations;
using StoredProcedureDemo.WebApp.Models;

namespace StoredProcedureDemo.WebApp.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductModelConfiguration());
        }
    }
}
