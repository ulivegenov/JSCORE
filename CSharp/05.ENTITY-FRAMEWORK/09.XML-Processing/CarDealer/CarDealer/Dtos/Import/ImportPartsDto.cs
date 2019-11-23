namespace CarDealer.Dtos.Import
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlRoot("parts")]
    public class ImportPartsDto
    {
        [XmlElement("partId")]
        public ImportPartIdDto[] PartsId { get; set; }
    }
}
