using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCore.EntityTypeConfigurations
{
    public class DeliveryCompanyConfiguration : IEntityTypeConfiguration<DeliveryCompany>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompany> builder)
        {
            builder.ToTable("DeliveryCompanies");

            builder.HasKey(dc => dc.DeliveryCompanyId);

            builder.Property(dc => dc.CompanyName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(dc => dc.ContactPhone)
                .HasMaxLength(20);

            builder.Property(dc => dc.ContactEmail)
                .HasMaxLength(255);

            builder.HasMany(dc => dc.DeliveryPersons)
                .WithOne(dp => dp.DeliveryCompany)
                .HasForeignKey(dp => dp.DeliveryCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
