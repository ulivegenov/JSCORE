namespace Facade
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarAddresBuilder : CarBuilderFacade
    {
        public CarAddresBuilder(Car car)
        {
            this.Car = car;
        }

        public CarAddresBuilder InCity(string city)
        {
            this.Car.City = city;
            return this;
        }

        public CarAddresBuilder AtAddress(string address)
        {
            this.Car.Address = address;
            return this;
        }
    }
}
