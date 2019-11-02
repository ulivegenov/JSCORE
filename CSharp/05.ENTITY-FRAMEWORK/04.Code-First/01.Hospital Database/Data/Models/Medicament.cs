namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        //[Key] --> if you don't want to use Fluent API
        public int MedicamentId { get; set; }

        //[Required] --> if you don't want to use Fluent API
        //[MaxLength(50)] --> if you don't want to use Fluent API
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
