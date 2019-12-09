namespace VaporStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Data.Models.Enums;

    public class Card
    {
        //•	Id – integer, Primary Key
        //•	Number – text, which consists of 4 pairs of 4 digits, separated by spaces(ex. “1234 5678 9012 3456”) (required)
        //•	Cvc – text, which consists of 3 digits(ex. “123”) (required)
        //•	Type – enumeration of type CardType, with possible values(“Debit”, “Credit”) (required)
        //•	UserId – integer, foreign key(required)
        //•	User – the card’s user(required)
        //•	Purchases – collection of type Purchase

        public int Id { get; set; }

        [Required]
        [RegularExpression(@"(\d{4}\s){3}\d{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"\d{3}")]
        public string Cvc { get; set; }

        public CardType Type { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}
