namespace Cinema.Data.EntityConfiguration
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            // Primary key
            builder.HasKey(t => t.Id);

            // Relations
            builder.HasOne(t => t.Customer)
                   .WithMany(c => c.Tickets)
                   .HasForeignKey(t => t.CustomerId);

            builder.HasOne(t => t.Projection)
                   .WithMany(p => p.Tickets)
                   .HasForeignKey(t => t.ProjectionId);
        }
    }
}
