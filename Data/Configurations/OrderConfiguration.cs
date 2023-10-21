using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Comments).HasMaxLength(1000);
           // builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x =>x.CustomerId).HasPrincipalKey(x=> x.Id);
           //builder.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressId).HasPrincipalKey(x => x.Id);
            builder.HasMany(x => x.Products).WithOne().HasForeignKey(x =>x.OrderId).HasPrincipalKey(x => x.Id);
            
        }
    }
}
