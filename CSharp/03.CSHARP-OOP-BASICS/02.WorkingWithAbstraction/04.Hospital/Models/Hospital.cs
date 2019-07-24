using System.Collections.Generic;

namespace _04Hospital.Models
{
    public class Hospital
    {
        private List<Department> innerListDepartments = new List<Department>();
        private List<Doctor> innerListDoctors = new List<Doctor>();

        public Hospital()
        {
            this.Departments = innerListDepartments;
            this.Doctors = innerListDoctors;
        }

        public IReadOnlyCollection<Department> Departments { get; private set; }

        public IReadOnlyCollection<Doctor> Doctors { get; private set; }

        public void AddDepartment(Department department)
        {
            innerListDepartments.Add(department);
        }

        public void AddDoctor(Doctor doctor)
        {
            innerListDoctors.Add(doctor);
        }
    }
}
