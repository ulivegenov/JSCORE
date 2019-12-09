namespace MusicHub.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MusicHub.Data.Models;

    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> album)
        {
            // Primary key
            album.HasKey(a => a.Id);

            //Relations
            album.HasOne(a => a.Producer)
                 .WithMany(p => p.Albums)
                 .HasForeignKey(a => a.ProducerId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
