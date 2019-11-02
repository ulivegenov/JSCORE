namespace P01_HospitalDatabase.Core
{
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class CommandUserInterface
    {
        public void Login(HospitalContext context)
        {
            Console.WriteLine("Login please!");
            Console.Write("Please, enter email: ");
            string email = Console.ReadLine();

            var emails = context.Doctors.Select(d => d.Email)
                                        .ToList();

            if (emails.Any(e => e == email))
            {
                Console.Write("Please, enter password: ");
                string password = Console.ReadLine();

                var paswords = context.Doctors.Select(d => d.Password)
                                              .ToList();

                if (paswords.Any(p => p == password))
                {
                    var doctor = context.Doctors.Select(d => new
                                                     {
                                                         d.Name,
                                                         d.Email,
                                                         d.Specialty
                                                     })
                                                     .FirstOrDefault(d => d.Email == email);

                    Console.WriteLine($"Welcome, dr. {doctor.Name} ({doctor.Specialty})");
                    Console.WriteLine("What do you want to do? Create Patient, or select an existing one?");
                    Console.Write("Please, write C/S: ");
                    string answer = Console.ReadLine();

                    if (answer.ToUpper() == "C")
                    {
                        this.CreatePatient(context);
                    }
                    else if (true)
                    {
                        this.SelectPatient(context);
                    }
                    else
                    {
                        throw new ArgumentException("This is incorrect answer!");
                    }
                }
                else
                {
                    throw new ArgumentException("Inccorect password!");
                }
            }
            else
            {
                throw new ArgumentException("Inccorect email!");
            }
        }

        public void Register(HospitalContext context)
        {
            Console.WriteLine("Register please!");
            List<string> doctorData = this.InputDoctorData();

            Doctor doctor = new Doctor();
            doctor.Name = doctorData[0];
            doctor.Specialty = doctorData[1];
            doctor.Email = doctorData[2];
            doctor.Password = doctorData[3];

            context.Doctors.Add(doctor);

            context.SaveChanges();

            this.Login(context);
        }

        private List<string> InputDoctorData()
        {
            List<string> data = new List<string>();

            Console.Write("Please, enter your names: ");
            string names = Console.ReadLine();
            data.Add(names);

            Console.Write("Please, enter your specialty: ");
            string specialty = Console.ReadLine();
            data.Add(specialty);

            Console.Write("Please, enter your email: ");
            string email = Console.ReadLine();
            data.Add(email);

            Console.Write("Please, enter your password: ");
            string password = Console.ReadLine();
            data.Add(password);

            return data;
        }

        private void CreatePatient(HospitalContext context)
        {
            List<string> patientData = InputPatientData();

            Patient patient = new Patient();
            patient.FirstName = patientData[0];
            patient.LastName = patientData[1];
            patient.Address = patientData[2];
            patient.Email = patientData[3];
            if (patientData[4].ToUpper() == "Y")
            {
                patient.HasInsurance = true;
            }
            else if (patientData[4].ToUpper() == "N")
            {
                patient.HasInsurance = false;
            }
            else
            {
                throw new ArgumentException("Incorrect answer!");
            }

            context.Patients.Add(patient);

            context.SaveChanges();

            this.SelectPatient(context);
            
        }

        private List<string> InputPatientData()
        {
            List<string> data = new List<string>();

            Console.Write("Please, enter patient's first name: ");
            string firstName = Console.ReadLine();
            data.Add(firstName);

            Console.Write("Please, enter patient's last name: ");
            string lastName = Console.ReadLine();
            data.Add(lastName);

            Console.Write("Please, enter patient's address: ");
            string address = Console.ReadLine();
            data.Add(address);

            Console.Write("Please, enter patient's email: ");
            string email = Console.ReadLine();
            data.Add(email);

            Console.WriteLine("Please, enter if patient has insurance!");
            Console.Write("Write Y/N: ");
            string hasInsurance = Console.ReadLine();
            data.Add(hasInsurance);

            return data;
        }

        private void SelectPatient(HospitalContext context)
        {
            Console.Write("Please, enter patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            var patientIds = context.Patients.Select(p => p.PatientId)
                                             .ToList();

            if (patientIds.Any(p => p == patientId))
            {
                var patient = context.Patients.FirstOrDefault(p => p.PatientId == patientId);

                Console.WriteLine("What are you want to do read or edit?");
                Console.Write("Please, write R/E: ");
                string answer = Console.ReadLine();

                if (answer.ToUpper() == "R")
                {
                    ReadPatient(patient);
                }
                else if (answer.ToUpper() == "E")
                {
                    EditPatient(patient, context);
                }
                else
                {
                    throw new ArgumentException("Incorrect answer!");
                }
            }
            else
            {
                throw new ArgumentException("There is no patient with this ID!");
            }
        }

        private void ReadPatient(Patient patient)
        {
            Console.WriteLine($"Name: {patient.FirstName} {patient.LastName}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"Email: {patient.Email}");
            if (patient.HasInsurance)
            {
                Console.WriteLine($"HasInsurance: YES");
            }
            else
            {
                Console.WriteLine($"HasInsurance: NO!");
            }

            Console.WriteLine($"Visitations count: {patient.Visitations.Count}");
            Console.WriteLine($"Diagnoses count: {patient.Diagnoses.Count}");
            Console.WriteLine($"Prescriptions count: {patient.Prescriptions.Count}");

            Console.WriteLine("Do you want to see Visitations?");
            Console.Write("Please, write Y/N: ");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                foreach (var visitation in patient.Visitations)
                {
                    Console.WriteLine($"Date: {visitation.Date}");
                    Console.WriteLine($"Comments: {visitation.Comments}");
                    Console.WriteLine($"Doctor: {visitation.Doctor.Name} ({visitation.Doctor.Specialty})");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Do you want to see Diagnoses?");
            Console.Write("Please, write Y/N: ");
            answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                foreach (var diagnose in patient.Diagnoses)
                {
                    Console.WriteLine($"Name: {diagnose.Name}");
                    Console.WriteLine($"Comments: {diagnose.Comments}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Do you want to see Prescriptions?");
            Console.Write("Please, write Y/N: ");
            answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                Console.WriteLine($"Prescriptions list");
                foreach (var prescription in patient.Prescriptions)
                {
                    Console.WriteLine(prescription.Medicament.Name);
                    Console.WriteLine();
                }
            }
        }

        private void EditPatient(Patient patient, HospitalContext context)
        {
            //TO DO..
        }
    }
}
