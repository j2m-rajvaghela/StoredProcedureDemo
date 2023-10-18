using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredProcedureDemo.WebApp.Models;

namespace StoredProcedureDemo.WebApp.Configurations
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product_sp_demo");
            builder.HasKey(x => x.ProductId);

            builder
                .Property(x => x.ProductId)
                .HasColumnName("product_id")
                .HasColumnType("Bigint")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
               .Property(x => x.Name)
               .HasColumnName("name")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder
               .Property(x => x.Price)
               .HasColumnName("price")
               .HasColumnType("decimal(18,2)")
               .IsRequired();
        }
    }
}
