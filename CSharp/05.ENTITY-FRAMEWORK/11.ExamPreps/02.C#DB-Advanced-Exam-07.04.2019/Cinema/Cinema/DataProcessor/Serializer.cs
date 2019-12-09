namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                                .Where(m => m.Rating >= rating &&
                                       m.Projections.Any())
                                .OrderByDescending(m => m.Rating)
                                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                                .Select(m => new
                                {
                                    MovieName = m.Title,
                                    Rating = m.Rating.ToString("F2"),
                                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                                    Customers = m.Projections.SelectMany(p => p.Tickets)
                                                             .Select(t => new 
                                                             {
                                                                 FirstName = t.Customer.FirstName,
                                                                 LastName = t.Customer.LastName,
                                                                 Balance = t.Customer.Balance.ToString("F2")
                                                             })
                                                             .OrderByDescending(c => c.Balance)
                                                             .ThenBy(c => c.FirstName)
                                                             .ThenBy(c => c.LastName)
                                })
                                .Take(10)
                                .ToArray();

            return JsonConvert.SerializeObject(movies, Resolver());
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                                   .Where(c => c.Age >= age)
                                   .OrderByDescending(c => c.Tickets.Select(t => t.Price).Sum())
                                   .Select(c => new ExportCustomerDto()
                                   {
                                       FirstName = c.FirstName,
                                       LastName = c.LastName,
                                       SpentMoney = c.Tickets.Select(t => t.Price).Sum().ToString("F2"),
                                       SpentTime = TimeSpan.FromTicks(c.Tickets.Sum(t => t.Projection.Movie.Duration.Ticks))
                                                            .ToString("hh\\:mm\\:ss")
                                   })
                                   .Take(10)
                                   .ToArray();

            return ResultFormater<ExportCustomerDto[]>(customers, "Customers");
        }



        // Helper method
        private static JsonSerializerSettings Resolver()
        {
            return new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
        }

        // Helper method
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