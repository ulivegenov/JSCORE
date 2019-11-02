namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        //[Key] --> if you don't want to use Fluent API
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        //[MaxLength(250)] --> if you don't want to use Fluent API
        public string Comments { get; set; }

        //[ForeignKey(nameof(Patient))] --> if you don't want to use Fluent API
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        //[ForeignKey(nameof(Doctor))] --> if you don't want to use Fluent API
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
