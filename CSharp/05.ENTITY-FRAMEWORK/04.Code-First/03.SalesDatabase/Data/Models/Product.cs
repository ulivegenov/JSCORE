namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

        //ProductId
        //Name(up to 50 characters, unicode)
        //Quantity(real number)
        //Price
        //Sales


    public class Product
    {
        //[Key] --> if you don't want to use Fluent API
        public int ProductId { get; set; }

        //[Required] --> if you don't want to use Fluent API
        //[MaxLength(50)] --> if you don't want to use Fluent API
        public string Name { get; set; }

        //[MaxLength(250)] --> if you don't want to use Fluent API
        public string Description { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
