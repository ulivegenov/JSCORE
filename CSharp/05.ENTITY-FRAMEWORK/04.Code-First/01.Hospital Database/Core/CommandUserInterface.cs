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
                    Doctor doctor = context.Doctors.FirstOrDefault(d => d.Email == email);

                    Console.WriteLine($"Welcome, dr. {doctor.Name} ({doctor.Specialty})");
                    Console.WriteLine("What do you want to do? Create Patient, or select an existing one?");
                    Console.Write("Please, write C/S: ");
                    string answer = Console.ReadLine();

                    if (answer.ToUpper() == "C")
                    {
                        CreatePatient(doctor, context);
                    }
                    else if (answer.ToUpper() == "S")
                    {
                        SelectPatient(doctor, context);
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

            Login(context);
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

        private void CreatePatient(Doctor doctor, HospitalContext context)
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

            SelectPatient(doctor, context);
            
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

        private void SelectPatient(Doctor doctor, HospitalContext context)
        {
            Console.Write("Please, enter patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            var patientIds = context.Patients.Select(p => p.PatientId)
                                             .ToList();

            if (patientIds.Any(p => p == patientId))
            {
                var patient = context.Patients.FirstOrDefault(p => p.PatientId == patientId);

                int visitationId = GenerateVisitation(patient, doctor, context);

                Console.WriteLine("What are you want to do read or edit?");
                Console.Write("Please, write R/E: ");
                string answer = Console.ReadLine();

                if (answer.ToUpper() == "R")
                {
                    ReadPatient(patient, context);
                }
                else if (answer.ToUpper() == "E")
                {
                    EditPatient(visitationId, patient, context);
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

        private int GenerateVisitation(Patient patient, Doctor doctor, HospitalContext context)
        {
            var visitation = new Visitation();
            visitation.Date = DateTime.UtcNow;
            visitation.DoctorId = doctor.DoctorId;
            visitation.Doctor = doctor;
            visitation.PatientId = patient.PatientId;
            visitation.Patient = visitation.Patient;

            context.Visitations.Add(visitation);
            context.SaveChanges();

            var lastVisitation = context.Visitations.Last();

            return lastVisitation.VisitationId;
        }

        private void ReadPatient(Patient patient, HospitalContext context)
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
            var patientVisitations = context.Visitations.Where(v => v.PatientId == patient.PatientId).ToList();
            var patientDiagnoses = context.Diagnoses.Where(d => d.PatientId == patient.PatientId).ToList();
            var patientPrescriptions = context.PatientMedicaments.Where(pm => pm.PatientId == patient.PatientId).ToList();

            Console.WriteLine($"Visitations count: {patientVisitations.Count}");
            Console.WriteLine($"Diagnoses count: {patientDiagnoses.Count}");
            Console.WriteLine($"Prescriptions count: {patientPrescriptions.Count}");
            Console.WriteLine();

            Console.WriteLine("Do you want to see Visitations?");
            Console.Write("Please, write Y/N: ");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                foreach (var visitation in patientVisitations)
                {
                    var doctor = context.Doctors.FirstOrDefault(d => d.DoctorId == visitation.DoctorId);

                    Console.WriteLine($"Date: {visitation.Date}");
                    Console.WriteLine($"Comments: {visitation.Comments}");
                    Console.WriteLine($"Doctor: {doctor.Name} ({doctor.Specialty})");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Do you want to see Diagnoses?");
            Console.Write("Please, write Y/N: ");
            answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                foreach (var diagnose in patientDiagnoses)
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
                foreach (var prescription in patientPrescriptions)
                {
                    var medicament = context.Medicaments.FirstOrDefault(m => m.MedicamentId == prescription.MedicamentId);

                    Console.WriteLine(medicament.Name);
                }
                Console.WriteLine();
            }
        }

        private void EditPatient(int visitationId, Patient patient, HospitalContext context)
        {
            Console.WriteLine("Select Diagnose");
            Console.Write("Please write diagnoseName: ");
            string diagnoseName = Console.ReadLine();

            Diagnose diagnose = GetDiagnose(diagnoseName, patient, context);
            if (diagnose == null)
            {
                diagnose = GenerateDiagnose(diagnoseName, patient, context);
            }

            patient.Diagnoses.Add(diagnose);
            context.SaveChanges();

            Console.WriteLine("Do you want to make comments to this Diagnose?");
            Console.Write("Please write Y/N: ");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                Console.Write("Write coments: ");
                string comments = Console.ReadLine();

                AddDiagnoseComments(comments, diagnose, context);
            }

            Console.WriteLine("Do you want to make a Prescriptions?");
            Console.Write("Please write Y/N: ");
            answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                Console.WriteLine("Write mdicaments names:");
                string medicamentName = "";

                while ((medicamentName = Console.ReadLine()) != String.Empty)
                {
                    Medicament currentMedicament = GetMedicament(medicamentName, context);

                    if (currentMedicament == null)
                    {
                        currentMedicament = GenerateMedicament(medicamentName, context);
                    }



                    PatientMedicament patientMedicament = GetPatientMedicament(currentMedicament, patient, context);

                    if (patientMedicament == null)
                    {
                        patientMedicament = GeneratePatientMedicament(currentMedicament, patient, context);
                    }

                    AddPrescription(patientMedicament, currentMedicament, patient, context);
                }  
            }

            Console.WriteLine("Do you want to add Comments to this Visitation?");
            Console.Write("Please write Y/N: ");
            answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                Visitation visitation = GetVisitation(visitationId, context);
                patient.Visitations.Add(visitation);
                context.SaveChanges();

                Console.WriteLine("Write coments: ");
                string comments = Console.ReadLine();

                Visitation currentVisitation = AddVisitationComments(comments, visitation, context);

                patient.Visitations.Add(currentVisitation);
                context.SaveChanges();

                //Console.WriteLine(patient);
            }
        }

        private Diagnose GetDiagnose(string diagnoseName, Patient patient, HospitalContext context)
        {
            return context.Diagnoses.FirstOrDefault(d => d.Name == diagnoseName && 
                                                                      d.PatientId == patient.PatientId);
        }

        private void AddDiagnoseComments(string comments, Diagnose diagnose, HospitalContext context)
        {
            diagnose.Comments = comments;
            context.SaveChanges();
        }

        private Diagnose GenerateDiagnose(string diagnoseName, Patient patient, HospitalContext context)
        {
            Diagnose diagnose = new Diagnose();
            diagnose.Name = diagnoseName;
            diagnose.PatientId = patient.PatientId;
            diagnose.Patient = patient;

            context.Diagnoses.Add(diagnose);
            context.SaveChanges();

            Diagnose currentDiagnose = context.Diagnoses.FirstOrDefault(d => d.Name == diagnoseName &&
                                                                             d.PatientId == patient.PatientId);
            return currentDiagnose;
        }

        private Visitation AddVisitationComments(string comments, Visitation visitation, HospitalContext context)
        {
            visitation.Comments = comments;
            context.SaveChanges();

            return context.Visitations.FirstOrDefault(v => v.VisitationId == visitation.VisitationId);
        }

        private Visitation GetVisitation(int visitationId, HospitalContext context)
        {
            return context.Visitations.FirstOrDefault(v => v.VisitationId == visitationId);
        }

        private void AddPrescription(PatientMedicament patientMedicament, Medicament currentMedicament, Patient patient, HospitalContext context)
        {
            currentMedicament.Prescriptions.Add(patientMedicament);
            context.SaveChanges();

            patient.Prescriptions.Add(patientMedicament);
            context.SaveChanges();
        }

        private static PatientMedicament GetPatientMedicament(Medicament currentMedicament, Patient patient, HospitalContext context)
        {
            return context.PatientMedicaments.FirstOrDefault(pm => pm.MedicamentId == currentMedicament.MedicamentId &&
                                                                   pm.PatientId == patient.PatientId);
        }

        private PatientMedicament GeneratePatientMedicament(Medicament currentMedicament, Patient patient, HospitalContext context)
        {
            var patientMedicament = new PatientMedicament();
            patientMedicament.MedicamentId = currentMedicament.MedicamentId;
            patientMedicament.Medicament = currentMedicament;
            patientMedicament.PatientId = patient.PatientId;
            patientMedicament.Patient = patient;

            context.PatientMedicaments.Add(patientMedicament);
            context.SaveChanges();

            PatientMedicament currentPatientMedicament = context.PatientMedicaments
                                                                .FirstOrDefault(pm => pm.MedicamentId == currentMedicament.MedicamentId &&
                                                                                      pm.PatientId == patient.PatientId);
           

            return currentPatientMedicament;
        }

        private Medicament GetMedicament(string medicamentName, HospitalContext context)
        {
            return context.Medicaments.FirstOrDefault(m => m.Name == medicamentName);
        }

        private Medicament GenerateMedicament(string medicamentName, HospitalContext context)
        {
            Medicament medicament = new Medicament();
            medicament.Name = medicamentName;

            context.Medicaments.Add(medicament);
            context.SaveChanges();

            return context.Medicaments.FirstOrDefault(m => m.Name == medicamentName);
        }
    }
}
