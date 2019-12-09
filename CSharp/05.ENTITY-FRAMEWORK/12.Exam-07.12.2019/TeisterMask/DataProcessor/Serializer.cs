namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                                  .Where(p => p.Tasks.Any())
                                  .Select(p => new ExportProjectDto()
                                  {
                                      TasksCount = p.Tasks.Count,
                                      ProjectName = p.Name,
                                      HasEndDate = p.DueDate == null
                                                   ? "No"
                                                   : "Yes",
                                      Tasks = p.Tasks
                                               .Select(t => new ExportTaskDto()
                                               {
                                                   Name = t.Name,
                                                   Label = t.LabelType.ToString()
                                               })
                                               .OrderBy(t => t.Name)
                                               .ToArray()
                                  })
                                  .OrderByDescending(p => p.TasksCount)
                                  .ThenBy(p => p.ProjectName)
                                  .ToArray();

            return ResultFormater<ExportProjectDto[]>(projects, "Projects");
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                                   .Where(e => e.EmployeesTasks.Any(et => DateTime.Compare(et.Task.OpenDate, date) >= 0))
                                   .Select(e => new
                                   {
                                       Username = e.Username,
                                       Tasks = e.EmployeesTasks
                                                .Where(ets => DateTime.Compare(ets.Task.OpenDate, date) >= 0)
                                                .Select(et => new
                                                {
                                                    TaskName = et.Task.Name,
                                                    OpenDate = et.Task.OpenDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                                                    DueDate = et.Task.DueDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                                                    LabelType = et.Task.LabelType.ToString(),
                                                    ExecutionType = et.Task.ExecutionType.ToString()
                                                })
                                                .OrderByDescending(et => DateTime.Parse(et.DueDate))
                                                .ThenBy(et => et.TaskName)
                                   })
                                   .OrderByDescending(e => e.Tasks.Count())
                                   .ThenBy(e => e.Username)
                                   .Take(10)
                                   .ToArray();


            return JsonConvert.SerializeObject(employees, Resolver());
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