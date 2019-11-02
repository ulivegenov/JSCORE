namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Diagnose
    {
        //[Key] --> if you don't want to use Fluent API
        public int DiagnoseId { get; set; }

        //[Required] --> if you don't want to use Fluent API
        //[MaxLength(50)] --> if you don't want to use Fluent API
        public string Name { get; set; }

        //[MaxLength(250)] --> if you don't want to use Fluent API
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
