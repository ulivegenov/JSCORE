namespace ProductShop.Dtos.Export
{
    using ProductShop.Interfaces;
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductInRangeDto : IDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
