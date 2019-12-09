namespace VaporStore.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using VaporStore.Data.Models;

    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        //•	Id – integer, Primary Key
        //•	Number – text, which consists of 4 pairs of 4 digits, separated by spaces(ex. “1234 5678 9012 3456”) (required)
        //•	Cvc – text, which consists of 3 digits(ex. “123”) (required)
        //•	Type – enumeration of type CardType, with possible values(“Debit”, “Credit”) (required)
        //•	UserId – integer, foreign key(required)
        //•	User – the card’s user(required)
        //•	Purchases – collection of type Purchase
        public void Configure(EntityTypeBuilder<Card> card)
        {
            //Primary key
            card.HasKey(c => c.Id);

            //Relations
            card.HasOne(c => c.User)
                .WithMany(u => u.Cards)
                .HasForeignKey(c => c.UserId);
        }
    }
}
