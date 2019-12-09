namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        public int CustomerId { get; set; }

        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }
    }
}
