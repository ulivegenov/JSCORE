using _04Hospital.Models;
using System;
using System.Linq;

namespace _04Hospital
{
    public class Engine
    {
        public void Run()
        {
            Hospital hospital = new Hospital();
            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command.Split();
                string departmentName = tokens[0];
                string doctorName = $"{tokens[1]} {tokens[2]}";
                string patientName = tokens[3];

                if (!(hospital.Departments.Any(n => n.Name == departmentName)))
                {
                    Department department = new Department(departmentName);
                    hospital.AddDepartment(department);
                }

                if (!(hospital.Doctors.Any(n => n.Name == doctorName)))
                {
                    Doctor doctor = new Doctor(doctorName);
                    hospital.AddDoctor(doctor);
                }

                Patient patient = new Patient(patientName);

                hospital.Departments.FirstOrDefault(n => n.Name == departmentName)
                                    .AddPatientToDepartment(patient);
                if (patient.Status == "Added")
                {
                    hospital.Doctors.FirstOrDefault(n => n.Name == doctorName).AddPatient(patient);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                if (tokens.Length == 1)
                {
                    string departmentName = tokens[0];
                    foreach (var department in hospital.Departments.Where(n => n.Name == departmentName))
                    {
                        foreach (var room in department.Rooms)
                        {
                            foreach (var patient in room.Patients)
                            {
                                Console.WriteLine(patient.Name);
                            }
                        }
                    }
                }
                else
                {
                    if (int.TryParse(tokens[1], out int result))
                    {
                        string departmentName = tokens[0];
                        int roomNumber = int.Parse(tokens[1]);

                        foreach (var department in hospital.Departments.Where(n => n.Name == departmentName))
                        {
                            foreach (var room in department.Rooms.Where(r => r.Number == roomNumber))
                            {
                                foreach (var patient in room.Patients.OrderBy(p => p.Name))
                                {
                                    Console.WriteLine(patient.Name);
                                }
                            }
                        }
                    }
                    else
                    {

                        foreach (var doctor in hospital.Doctors.Where(d => d.Name == command.TrimEnd()))
                        {
                            foreach (var patient in doctor.Patients.OrderBy(p => p.Name))
                            {
                                Console.WriteLine(patient.Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
