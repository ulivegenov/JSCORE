namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                                   .Where(p => ids.Contains(p.Id))
                                   .Select(p => new
                                   {
                                       Id = p.Id,
                                       Name = p.FullName,
                                       CellNumber = p.Cell.CellNumber,
                                       Officers = p.PrisonerOfficers
                                                    .OrderBy(o => o.Officer.FullName)
                                                    .ThenBy(o => o.OfficerId)
                                                    .Select(po => new
                                                    {
                                                        OfficerName = po.Officer.FullName,
                                                        Department = po.Officer.Department.Name
                                                    }),
                                       TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
                                   })
                                   .OrderBy(p => p.Name)
                                   .ThenBy(p => p.Id)
                                   .ToArray();

            return JsonConvert.SerializeObject(prisoners, Resolver());
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] names = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                                   .Where(p => names.Contains(p.FullName))
                                   .Select(p => new ExportPrisonerDto()
                                   {
                                       Id = p.Id,
                                       Name = p.FullName,
                                       IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                                       EncryptedMessages = p.Mails
                                                            .Select(m => new ExportMessageDto()
                                                            {
                                                                Description = Reverse(m.Description)
                                                            })
                                                            .ToArray()
                                   })
                                   .OrderBy(p => p.Name)
                                   .ThenBy(p => p.Id)
                                   .ToArray();

            return ResultFormater<ExportPrisonerDto[]>(prisoners, "Prisoners");
        }


        // Helper method
        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
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