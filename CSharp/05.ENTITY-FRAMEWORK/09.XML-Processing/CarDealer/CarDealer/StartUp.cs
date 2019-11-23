namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Dtos.Export;
    using Data;
    using Dtos.Import;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var xmlString = File.ReadAllText("./../../../Datasets/sales.xml");

                var result = GetSalesWithAppliedDiscount(db);
                Console.WriteLine(result);
            }
        }


        //09. Import Suppliers 
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = Mapper.Map<Supplier[]>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}";
        }


        //10. Import Parts 
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));
            var validSupplierIds = context.Suppliers.Select(s => s.Id);

            var parts = Mapper.Map<Part[]>(partsDto)
                               .Where(p => validSupplierIds.Contains(p.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}";
        }


        //11. Import Cars 
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            var carsDto = (ImportCarDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);

                context.Cars.Add(car);

                foreach (var part in carDto.Parts.PartsId)
                {
                    if (car.PartCars.FirstOrDefault(pc => pc.PartId == part.PartId) == null 
                                                    && context.Parts.Find(part.PartId) != null)
                    {
                        var partCar = new PartCar()
                        {
                            CarId = car.Id,
                            PartId = part.PartId
                        };

                        car.PartCars.Add(partCar);
                    }
                }
            }


            context.Cars.Count();
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}";
        }


        //12. Import Customers 
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = Mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();
            
            return $"Successfully imported {context.Customers.Count()}";
        }


        //13. Import Sales 
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            var salesDto = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var validCarIds = context.Cars.Select(c => c.Id).ToArray();
            var validCustomerIds = context.Customers.Select(c => c.Id).ToArray();

            var sales = Mapper.Map<Sale[]>(salesDto)
                              .Where(s => validCarIds.Contains(s.CarId));

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}";
        }


        //14. Export Cars With Distance 
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                              .Where(c => c.TravelledDistance > 2000000)
                              .OrderBy(c => c.Make)
                              .ThenBy(c => c.Model)
                              .Select(c => new ExportCarWithDistanceDto()
                              {
                                  Make = c.Make,
                                  Model = c.Model,
                                  TravelledDistance = c.TravelledDistance
                              })
                              .Take(10)
                              .ToArray();

            return ResultFormater<ExportCarWithDistanceDto[]>(cars, "cars");
        }


        //15. Export Cars From Make BMW 
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                                 .Where(c => c.Make == "BMW")
                                 .OrderBy(c => c.Model)
                                 .ThenByDescending(c => c.TravelledDistance)
                                 .Select(c => new ExportBmwDto()
                                 {
                                     Id = c.Id,
                                     Model = c.Model,
                                     TravelledDistance = c.TravelledDistance
                                 })
                                 .ToArray();

            return ResultFormater<ExportBmwDto[]>(bmwCars, "cars");
        }


        //16. Export Local Suppliers 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            //Manual mapping
            var suppliers = context.Suppliers
                                   .Where(s => s.IsImporter == false)
                                   .Select(s => new ExportSupplierDto()
                                   {
                                       Id = s.Id,
                                       Name = s.Name,
                                       PartsCount = s.Parts.Count()
                                   })
                                   .ToArray();

            //Auto mapping -> Just to Exercise
            var suppliersAuto = context.Suppliers
                                    .Where(s => !s.IsImporter)
                                    .ProjectTo<ExportSupplierDto>()
                                    .ToArray();

            return ResultFormater<ExportSupplierDto[]>(suppliersAuto, "suppliers");
        }


        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                              .Select(c => new ExportCarWithPartsDto()
                              {
                                  Make = c.Make,
                                  Model = c.Model,
                                  TravelledDistance = c.TravelledDistance,
                                  Parts = c.PartCars.Select(pc => new ExportPartDto()
                                  {
                                      Name = pc.Part.Name,
                                      Price = pc.Part.Price
                                  })
                                  .OrderByDescending(pc => pc.Price)
                                  .ToArray()
                              })
                              .OrderByDescending(c => c.TravelledDistance)
                              .ThenBy(c => c.Model)
                              .Take(5)
                              .ToArray();

            return ResultFormater<ExportCarWithPartsDto[]>(cars, "cars");
        }


        //18. Export Total Sales By Customer 
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                                   .Where(c => c.Sales.Any())
                                   .Select(c => new ExportSalesByCustomerDto()
                                   {
                                       FullName = c.Name,
                                       BoughtCars = c.Sales.Count(),
                                       SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                                   })
                                   .OrderByDescending(c => c.SpentMoney)
                                   .ToArray();

            return ResultFormater<ExportSalesByCustomerDto[]>(customers, "customers");
        }


        //19. Export Sales With Applied Discount 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                               .Select(s => new ExportSaleDto()
                               {
                                   Car = new ExportSaleCarDto()
                                   {
                                       Make = s.Car.Make,
                                       Model = s.Car.Model,
                                       TravelledDistance = s.Car.TravelledDistance
                                   },
                                   Dicount = s.Discount,
                                   CustomerName = s.Customer.Name,
                                   Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                                   PriceWithDicount = s.Car.PartCars.Sum(pc => pc.Part.Price)
                                                        - s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100
                               })
                               .ToArray();

            return ResultFormater<ExportSaleDto[]>(sales, "sales");
        }


        //Helper method
        private static string ResultFormater<T>(T selection, string rootAttributeName)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootAttributeName));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), selection, namespaces);

            return sb.ToString().Trim();
        }
    }
}