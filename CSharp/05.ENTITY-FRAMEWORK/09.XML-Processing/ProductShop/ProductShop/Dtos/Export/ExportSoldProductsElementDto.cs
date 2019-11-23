namespace ProductShop.Dtos.Export
{
    using ProductShop.Models;
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExportSoldProductsElementDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportSoldProductsDto[] Products { get; set; }
    }
}
