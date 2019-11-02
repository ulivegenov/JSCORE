namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

        //CustomerId
        //Name(up to 100 characters, unicode)
        //Email(up to 80 characters, not unicode)
        //CreditCardNumber(string)
        //Sales


    public class Customer
    {
        //[Key] --> if you don't want to use Fluent API
        public int CustomerId { get; set; }

        //[Required] --> if you don't want to use Fluent API
        //[MaxLength(100)] --> if you don't want to use Fluent API
        public string Name { get; set; }

        //[MaxLength] --> if you don't want to use Fluent API
        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
