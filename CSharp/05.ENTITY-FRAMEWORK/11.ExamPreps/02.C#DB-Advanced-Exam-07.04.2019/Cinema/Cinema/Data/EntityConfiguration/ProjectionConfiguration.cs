namespace Cinema.Data.EntityConfiguration
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> builder)
        {
            // Primary key
            builder.HasKey(p => p.Id);

            // Realtions
            builder.HasOne(p => p.Movie)
                   .WithMany(m => m.Projections)
                   .HasForeignKey(p => p.MovieId);

            builder.HasOne(p => p.Hall)
                   .WithMany(h => h.Projections)
                   .HasForeignKey(p => p.HallId);
        }
    }
}
