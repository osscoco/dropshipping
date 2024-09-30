using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCore.EntityTypeConfigurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("Deliveries");

            builder.HasKey(d => d.DeliveryId);

            builder.Property(d => d.TrackingNumber)
                .HasMaxLength(50);

            builder.HasOne(d => d.Order)
                .WithOne(o => o.Delivery)
                .HasForeignKey<Delivery>(d => d.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.DeliveryAddress)
                .WithMany()
                .HasForeignKey(d => d.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.DeliveryPerson)
                .WithMany()
                .HasForeignKey(d => d.DeliveryPersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
