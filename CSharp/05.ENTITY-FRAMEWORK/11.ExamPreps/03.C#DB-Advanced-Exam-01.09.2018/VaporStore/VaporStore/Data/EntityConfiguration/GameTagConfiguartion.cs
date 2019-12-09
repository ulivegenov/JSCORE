namespace VaporStore.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using VaporStore.Data.Models;

    public class GameTagConfiguartion : IEntityTypeConfiguration<GameTag>
    {
        //•	GameId – integer, Primary Key, foreign key(required)
        //•	TagId – integer, Primary Key, foreign key(required)
        //•	Game – Game
        //•	Tag – Tag

        public void Configure(EntityTypeBuilder<GameTag> gameTag)
        {
            //Primary key
            gameTag.HasKey(gt => new { gt.GameId, gt.TagId });

            //Relations
            gameTag.HasOne(gt => gt.Game)
                   .WithMany(g => g.GameTags)
                   .HasForeignKey(gt => gt.GameId);

            gameTag.HasOne(gt => gt.Tag)
                   .WithMany(t => t.GameTags)
                   .HasForeignKey(gt => gt.TagId);
        }
    }
}
