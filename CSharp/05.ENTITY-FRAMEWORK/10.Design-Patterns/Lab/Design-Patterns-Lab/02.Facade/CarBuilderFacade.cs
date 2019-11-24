namespace Facade
{
    public class CarBuilderFacade
    {
        public CarBuilderFacade()
        {
            this.Car = new Car();
        }

        protected Car Car { get; set; }

        public Car Build() => this.Car;

        public CarInfoBuilder Info => new CarInfoBuilder(this.Car);
        public CarAddresBuilder Built => new CarAddresBuilder(this.Car);
    }
}
