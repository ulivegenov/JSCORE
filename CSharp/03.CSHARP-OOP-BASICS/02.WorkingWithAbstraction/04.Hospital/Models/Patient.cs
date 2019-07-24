namespace _04Hospital.Models
{
    public class Patient
    {
        public Patient(string name)
        {
            this.Name = name;
            this.Status = "Not added";
        }

        public string Name { get; private set; }

        public string Status { get; set; }
    }
}
