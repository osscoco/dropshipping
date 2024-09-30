using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCore.EntityTypeConfigurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.TicketId);

            builder.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.CreatedDate)
                .IsRequired();

            builder.Property(t => t.UpdatedDate)
                .HasDefaultValue(null);

            builder.HasOne(t => t.Client)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Support)
                .WithMany(s => s.SupportedTickets)
                .HasForeignKey(t => t.SupportId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
