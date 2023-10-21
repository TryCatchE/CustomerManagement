using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Addresses)
                .WithOne()
                .HasForeignKey(x => x.CustomerId)
                .HasPrincipalKey(x => x.Id);
            
            builder.HasMany(x =>x.Orders)
                .WithOne()
                .HasForeignKey(x =>x.CustomerId)
                .HasPrincipalKey(x =>x.Id);
        }
    }
}
