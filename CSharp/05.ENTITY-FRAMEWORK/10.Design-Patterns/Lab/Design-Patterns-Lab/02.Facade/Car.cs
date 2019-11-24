namespace Facade
{
    public class Car
    {
        public string Type { get; set; }

        public string Color { get; set; }

        public int NumberOfDoors { get; set; }


        public string City { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return $"Car Type: {this.Type}, Color: {this.Color}, Number of doors: {this.NumberOfDoors}," +
                        $" Manifactured in {this.City}, at address {this.Address}";
        }
    }
}
