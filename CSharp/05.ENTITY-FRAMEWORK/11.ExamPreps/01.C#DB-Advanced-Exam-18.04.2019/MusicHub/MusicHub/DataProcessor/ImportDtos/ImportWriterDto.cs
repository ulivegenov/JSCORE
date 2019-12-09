namespace MusicHub.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    public class ImportWriterDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression("^[A-Z][a-z]+ [A-Z][a-z]+$", ErrorMessage = "Pseudonym must be properly formatted.")]
        public string Pseudonym { get; set; }
    }
}
