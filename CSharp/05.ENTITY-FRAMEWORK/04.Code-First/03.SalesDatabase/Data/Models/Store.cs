namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

        //StoreId
        //Name(up to 80 characters, unicode)
        //Sales


    public class Store
    {
        //[Key] --> if you don't want to use Fluent API
        public int StoreId { get; set; }

        //[Required] --> if you don't want to use Fluent API
        //[MaxLength(80)] --> if you don't want to use Fluent API
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
