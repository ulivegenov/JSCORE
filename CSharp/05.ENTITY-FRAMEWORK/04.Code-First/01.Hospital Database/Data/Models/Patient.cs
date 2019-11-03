namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        //[Key] --> if you don't want to use Fluent API
        public int PatientId { get; set; }

        //[Required] --> if you don't want to use Fluent API
        //[MaxLength(50)] --> if you don't want to use Fluent API
        public string FirstName { get; set; }

        //[Required] --> if you don't want to use Fluent API
        //[MaxLength(50)] --> if you don't want to use Fluent API
        public string LastName { get; set; }

        //[MaxLength(250)] --> if you don't want to use Fluent API
        public string Address { get; set; }

        //[MaxLength(80)] --> if you don't want to use Fluent API
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new List<Visitation>();

        public ICollection<Diagnose> Diagnoses { get; set; } = new List<Diagnose>();

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new List<PatientMedicament>();
    }
}
