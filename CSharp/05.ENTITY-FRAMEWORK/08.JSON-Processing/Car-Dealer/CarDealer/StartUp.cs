namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputJson = File.ReadAllText("./../../../Datasets/sales.json");

                var result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }
        }


        //09. Import Suppliers 
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}.";
        }


        //10. Import Parts 
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var validSupplierIds = context.Suppliers
                                          .Select(s => s.Id)
                                          .ToList();

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                                   .Where(p => validSupplierIds.Contains(p.SupplierId))
                                   .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}.";
        }


        //11. Import Cars 
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var inputCarsDto = JsonConvert.DeserializeObject<CarDto[]>(inputJson);
            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var currentCarDto in inputCarsDto)
            {
                var car = new Car
                {
                    Make = currentCarDto.Make,
                    Model = currentCarDto.Model,
                    TravelledDistance = currentCarDto.TravelledDistance
                };

                foreach (var part in currentCarDto.PartsId.Distinct())
                {
                    var partCar = new PartCar
                    {
                        PartId = part,
                        Car = car
                    };

                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }


        //12. Import Customers 
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }

        //13. Import Sales 
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }


        //14. Export Ordered Customers 
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                                   .OrderBy(c => c.BirthDate)
                                   .ThenBy(c => c.IsYoungDriver)
                                   .Select(c => new
                                   {
                                       c.Name,
                                       BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                                       IsYoungDriver = c.IsYoungDriver
                                   })
                                   .ToList();

            return JsonConvert.SerializeObject(customers, Resolver());
        }


        //15. Export Cars From Make Toyota 
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                              .Where(c => c.Make == "Toyota")
                              .OrderBy(c => c.Model)
                              .ThenByDescending(c => c.TravelledDistance)
                              .Select(c => new
                              {
                                  c.Id,
                                  c.Make,
                                  c.Model,
                                  c.TravelledDistance
                              })
                              .ToList();

            return JsonConvert.SerializeObject(cars, Resolver());
        }


        //16. Export Local Suppliers 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                   .Where(s => s.IsImporter == false)
                                   .Select(s => new
                                   {
                                       s.Id,
                                       s.Name,
                                       PartsCount = s.Parts.Count()
                                   })
                                   .ToList();

            return JsonConvert.SerializeObject(suppliers, Resolver());
        }


        //17. Export Cars With Their List Of Parts 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                              .Select(c => new
                              {
                                  car = new
                                  {
                                      c.Make,
                                      c.Model,
                                      c.TravelledDistance
                                  },
                                  parts = c.PartCars
                                           .Select(pc => new
                                           {
                                               Name = pc.Part.Name,
                                               Price = $"{pc.Part.Price:F2}"
                                           })
                              })
                              .ToList();

            return JsonConvert.SerializeObject(cars, Resolver());
        }


        //18. Export Total Sales By Customer 
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                                   .Where(c => c.Sales.Any())
                                   .Select(c => new
                                   {
                                       FullName = c.Name,
                                       BoughtCars = c.Sales.Count,
                                       SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                                   })
                                   .OrderByDescending(c => c.SpentMoney)
                                   .ThenByDescending(c => c.BoughtCars)
                                   .ToList();

            var resolver = Resolver();
            resolver.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return JsonConvert.SerializeObject(customers, Resolver());
        }


        //19. Export Sales With Applied Discount 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                               .Select(s => new
                               {
                                   car = new
                                   {
                                       s.Car.Make,
                                       s.Car.Model,
                                       s.Car.TravelledDistance
                                   },
                                   customerName = s.Customer.Name,
                                   Discount = $"{s.Discount:F2}",
                                   price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):F2}",
                                   priceWithDiscount = $"{s.Car.PartCars.Sum(x => x.Part.Price) * ((100m - s.Discount) / 100m):f2}"
                               })
                               .Take(10)
                               .ToList();

            return JsonConvert.SerializeObject(sales, Resolver());
        }


        private static JsonSerializerSettings Resolver()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
    }
}