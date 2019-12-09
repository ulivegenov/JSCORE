namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();
            List<Movie> movies = new List<Movie>();

            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            foreach (var movieDto in moviesDto)
            {
                bool isGenreValid = Enum.TryParse<Genre>(movieDto.Genre, out Genre genre);

                if (!IsValid(movieDto) || !isGenreValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration;
                if (!TimeSpan.TryParse(movieDto.Duration, out duration))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie()
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = duration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                movies.Add(movie);
                result.AppendLine(String.Format(SuccessfulImportMovie, movieDto.Title, movieDto.Genre, movieDto.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();
            List<Hall> halls = new List<Hall>();
            List<Seat> seats = new List<Seat>();

            var hallsDto = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            foreach (var hallDto in hallsDto)
            {
                if (!IsValid(hallDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall()
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    var seat = new Seat()
                    {
                        Hall = hall
                    };

                    seats.Add(seat);
                }

                var projectionType = hall.Is4Dx ? hall.Is3D ? "4Dx/3D" : "4Dx" : hall.Is3D ? "3D" : "Normal";

                result.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hallDto.Seats.ToString()));
            }

            context.Halls.AddRange(halls);
            context.Seats.AddRange(seats);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();
            List<Projection> projections = new List<Projection>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var projectionDto in projectionsDto)
            {
                var hall = context.Halls.FirstOrDefault(h => h.Id == projectionDto.HallId);
                var movie = context.Movies.FirstOrDefault(m => m.Id == projectionDto.MovieId);

                if (!IsValid(projectionDto) || hall == null || movie == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection()
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.Parse(projectionDto.DateTime, CultureInfo.InvariantCulture)
                };

                projections.Add(projection);
                result.AppendLine(String.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy")));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();
            List<Ticket> tickets = new List<Ticket>();
            List<Customer> customers = new List<Customer>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var customerDto in customersDto)
            {

                if (!IsValid(customerDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer()
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance  
                };

                customers.Add(customer);

                foreach (var ticketDto in customerDto.Tickets)
                {
                    var ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        ProjectionId = ticketDto.ProjectionId,
                        Customer = customer
                    };

                    tickets.Add(ticket);
                    //customer.Tickets.Add(ticket);
                }

                result.AppendLine(String.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customerDto.Tickets.Count()));
            }

            context.Customers.AddRange(customers);
            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}