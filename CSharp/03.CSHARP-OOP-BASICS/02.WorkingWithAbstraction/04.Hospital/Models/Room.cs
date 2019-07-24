using System;
using System.Collections.Generic;

namespace _04Hospital.Models
{
    public class Room
    {
        //private List<Patient> innerListPatients;

        public Room(int number)
        {
            this.Number = number;
            this.Patients = new List<Patient>();
        }

        public int Number { get; set; }

        public List<Patient> Patients { get; private set; }

        public void AddPatient(Patient patient)
        {
            if (this.Patients.Count >= 3)
            {
                throw new Exception();
            }

            this.Patients.Add(patient);
        }
    }
}
