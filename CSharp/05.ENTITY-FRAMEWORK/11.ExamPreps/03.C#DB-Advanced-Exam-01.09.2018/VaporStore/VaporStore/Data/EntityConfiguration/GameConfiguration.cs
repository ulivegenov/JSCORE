namespace VaporStore.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using VaporStore.Data.Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        //•	Id – integer, Primary Key
        //•	Name – text(required)
        //•	Price – decimal (non-negative, minimum value: 0) (required)
        //•	ReleaseDate – Date(required)
        //•	DeveloperId – integer, foreign key(required)
        //•	Developer – the game’s developer(required)
        //•	GenreId – integer, foreign key(required)
        //•	Genre – the game’s genre(required)
        //•	Purchases - collection of type Purchase
        //•	GameTags - collection of type GameTag.Each game must have at least one tag.
        public void Configure(EntityTypeBuilder<Game> game)
        {
            //Primary key
            game.HasKey(g => g.Id);

            //Relations
            game.HasOne(g => g.Developer)
                .WithMany(d => d.Games)
                .HasForeignKey(g => g.DeveloperId);

            game.HasOne(g => g.Genre)
                .WithMany(gr => gr.Games)
                .HasForeignKey(g => g.GenreId);
        }
    }
}
