namespace VaporStore.DataProcessor.ExportDtos
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlAttribute("username")]
        public string username { get; set; }
        [XmlArray("Purchases")]
        public ExportPurchaseDto[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }
    }
}
