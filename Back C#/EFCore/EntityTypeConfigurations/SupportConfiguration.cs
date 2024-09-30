using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Identity;

namespace EFCore.EntityTypeConfigurations
{
    public class SupportConfiguration : IEntityTypeConfiguration<Support>
    {
        public void Configure(EntityTypeBuilder<Support> builder)
        {
            builder.ToTable("Supports");

            builder.HasMany(s => s.SupportedTickets)
                .WithOne(t => t.Support)
                .HasForeignKey(t => t.SupportId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
