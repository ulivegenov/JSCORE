namespace VaporStore.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using VaporStore.Data.Models;

    public class PurchaseConfigurtion : IEntityTypeConfiguration<Purchase>
    {
        //•	Id – integer, Primary Key
        //•	Type – enumeration of type PurchaseType, with possible values(“Retail”, “Digital”) (required) 
        //•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes(ex. “ABCD-EFGH-1J3L”) (required)
        //•	Date – Date(required)
        //•	CardId – integer, foreign key(required)
        //•	Card – the purchase’s card(required)
        //•	GameId – integer, foreign key(required)
        //•	Game – the purchase’s game(required)
        public void Configure(EntityTypeBuilder<Purchase> purchase)
        {
            //Primary key
            purchase.HasKey(p => p.Id);

            //Relations
            purchase.HasOne(p => p.Card)
                    .WithMany(c => c.Purchases)
                    .HasForeignKey(p => p.CardId);

            purchase.HasOne(p => p.Game)
                    .WithMany(g => g.Purchases)
                    .HasForeignKey(p => p.GameId);
        }
    }
}
