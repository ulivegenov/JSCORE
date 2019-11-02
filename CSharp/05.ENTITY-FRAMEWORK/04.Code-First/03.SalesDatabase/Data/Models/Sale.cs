namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

        //SaleId
        //Date
        //Product
        //Customer
        //Store


    public class Sale
    {
        //[Key] --> if you don't want to use Fluent API
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        //[ForeignKey(nameof(Product))] --> if you don't want to use Fluent API
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //[ForeignKey(nameof(Customer))] --> if you don't want to use Fluent API
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //[ForeignKey(nameof(Store))] --> if you don't want to use Fluent API
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
