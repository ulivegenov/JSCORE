using System.Collections.Generic;

namespace _04Hospital.Models
{
    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<Patient>();
        }

        public string Name { get; set; }

        public List<Patient> Patients { get; private set; }

        public void AddPatient(Patient patient)
        {
            this.Patients.Add(patient);
        }
    }
}
