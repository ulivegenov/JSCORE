namespace ProductShop.Dtos.Export
{
    using ProductShop.Interfaces;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserSoldProductDto : IDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ExportSoldProductsDto[] SoldProducts { get; set; }
    }
}
