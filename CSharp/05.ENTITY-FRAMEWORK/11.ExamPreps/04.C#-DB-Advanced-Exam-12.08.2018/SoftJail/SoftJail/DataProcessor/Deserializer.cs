namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();
            List<Department> validDepartments = new List<Department>();

            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            foreach (var departmentDto in departmentsDto)
            {
                var isValid = IsValid(departmentDto) &&
                              departmentDto.Cells.All(IsValid);

                if (isValid)
                {
                    var department = new Department()
                    {
                        Name = departmentDto.Name,
                        Cells = departmentDto.Cells
                                             .Select(c => new Cell
                                             {
                                                 CellNumber = c.CellNumber,
                                                 HasWindow = c.HasWindow
                                             })
                                             .ToArray()
                    };

                    validDepartments.Add(department);

                    result.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                }
                else
                {
                    result.AppendLine("Invalid Data");
                }
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();
            List<Prisoner> validPrisoners = new List<Prisoner>();

            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            foreach (var prisonerDto in prisonersDto)
            {
                var releaseDate = prisonerDto.ReleaseDate == null
                                               ? (DateTime?)null
                                               : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var isValid = IsValid(prisonerDto) &&
                              prisonerDto.Mails.All(IsValid);

                if (isValid)
                {
                    var prisoner = new Prisoner()
                    {
                        FullName = prisonerDto.FullName,
                        Nickname = prisonerDto.Nickname,
                        Age = prisonerDto.Age,
                        IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ReleaseDate = releaseDate,
                        Bail = prisonerDto.Bail,
                        CellId = prisonerDto.CellId,
                        Mails = prisonerDto.Mails
                                       .Select(m => new Mail
                                       {
                                           Description = m.Description,
                                           Sender = m.Sender,
                                           Address = m.Sender
                                       })
                                       .ToArray()
                    };

                    validPrisoners.Add(prisoner);

                    result.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
                else
                {
                    result.AppendLine("Invalid Data");
                }
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();
            List<Officer> validOfficers = new List<Officer>();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
            //var officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var officersDto = ImporterXml<ImportOfficerDto>(xmlString, "Officers");


            foreach (var officerDto in officersDto)
            {
                var isPositionValid = Enum.TryParse(officerDto.Position, out Position position);
                var isWeaponValid = Enum.TryParse(officerDto.Weapon, out Weapon weapon);

                var isValid = IsValid(officerDto) &&
                              isPositionValid &&
                              isWeaponValid;

                if (isValid)
                {
                    var officer = new Officer()
                    {
                        FullName = officerDto.FullName,
                        Salary = officerDto.Salary,
                        Position = position,
                        Weapon = weapon,
                        DepartmentId = officerDto.DepartmentId,
                        OfficerPrisoners = officerDto.Prisoners
                                                     .Select(p => new OfficerPrisoner()
                                                     {
                                                         PrisonerId = p.Id
                                                     })
                                                     .ToArray()
                    };

                    validOfficers.Add(officer);

                    result.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                }
                else
                {
                    result.AppendLine("Invalid Data");
                }
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }


        //Helper method
        private static T[] ImporterXml<T>(string xmlString, string rootAttributeName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(rootAttributeName));

            return (T[])xmlSerializer.Deserialize(new StringReader(xmlString));
        }

        //Helper method
        public static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}