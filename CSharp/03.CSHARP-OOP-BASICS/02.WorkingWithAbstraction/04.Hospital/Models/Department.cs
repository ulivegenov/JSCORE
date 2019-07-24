using System.Collections.Generic;
using System.Linq;

namespace _04Hospital.Models
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();

            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room(i + 1));
            }
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; private set; }

        public void AddPatientToDepartment(Patient patient)
        {
            Room currentRoom = this.Rooms.FirstOrDefault(r => r.Patients.Count < 3);
            if (currentRoom != null)
            {
                currentRoom.AddPatient(patient);
                patient.Status = "Added";
            }
        }
    }
}
