namespace MusicHub.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MusicHub.Data.Models;

    public class SongPerformerConfiguraton : IEntityTypeConfiguration<SongPerformer>
    {
        public void Configure(EntityTypeBuilder<SongPerformer> songPerformer)
        {
            //Primary key
            songPerformer.HasKey(sp => new { sp.SongId, sp.PerformerId });

            //Relations
            songPerformer.HasOne(sp => sp.Song)
                         .WithMany(s => s.SongPerformers)
                         .HasForeignKey(sp => sp.SongId);

            songPerformer.HasOne(sp => sp.Performer)
                         .WithMany(p => p.PerformerSongs)
                         .HasForeignKey(sp => sp.PerformerId);
        }
    }
}
