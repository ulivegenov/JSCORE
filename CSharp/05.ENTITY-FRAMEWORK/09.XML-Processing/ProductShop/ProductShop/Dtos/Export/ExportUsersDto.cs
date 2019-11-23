namespace ProductShop.Dtos.Export
{
    using ProductShop.Models;
    using System.Xml.Serialization;

    [XmlType("Users")]
    public class ExportUsersDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUsersAgeDto[] Users { get; set; }
    }
}
