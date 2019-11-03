namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        //[Key] --> if you don't want to use Fluent API 
        public int DoctorId { get; set; }

        //[MaxLength(100)] --> if you don't want to use Fluent API
        public string Name { get; set; }

        //[Required] --> if you don't want to use Fluent API
        //[MaxLength(80)] --> if you don't want to use Fluent API
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }

        //[MaxLength(100)] --> if you don't want to use Fluent API
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new List<Visitation>();
    }
}
