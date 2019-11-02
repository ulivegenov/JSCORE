namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        //[ForeignKey("Patient")] --> if you don't want to use Fluent API
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        //[ForeignKey("Medicament")] --> if you don't want to use Fluent API
        public int MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
    }
}
