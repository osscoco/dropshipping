using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCore.EntityTypeConfigurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(co => co.CountryId);

            builder.Property(co => co.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
