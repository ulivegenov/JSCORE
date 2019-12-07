namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using System.IO;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();
            List<Project> validProjects = new List<Project>();

            var projectsDto = ImporterXml<ImportProjectDto>(xmlString, "Projects");

            foreach (var projectDto in projectsDto)
            {
                var isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate,
                                                             "dd/MM/yyyy",
                                                             CultureInfo.InvariantCulture,
                                                             DateTimeStyles.AdjustToUniversal,
                                                             out DateTime openDate);

                

                var isProjectValid = IsValid(projectDto) &&
                                     isOpenDateValid;

                if (isProjectValid)
                {
                    DateTime? dueDate;
                    if (String.IsNullOrWhiteSpace(projectDto.DueDate))
                    {
                        dueDate = null;
                    }
                    else
                    {
                        dueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    

                    var project = new Project()
                    {
                        Name = projectDto.Name,
                        OpenDate = openDate,
                        DueDate = dueDate
                    };

                    foreach (var taskDto in projectDto.Tasks)
                    {
                        var isTaskOpenDateValidFormat = DateTime.TryParseExact(taskDto.OpenDate,
                                                             "dd/MM/yyyy",
                                                             CultureInfo.InvariantCulture,
                                                             DateTimeStyles.AdjustToUniversal,
                                                             out DateTime taskOpenDate);

                        var isTaskDueDateValidFormat = DateTime.TryParseExact(taskDto.DueDate,
                                                             "dd/MM/yyyy",
                                                             CultureInfo.InvariantCulture,
                                                             DateTimeStyles.AdjustToUniversal,
                                                             out DateTime taskDueDate);

                        var isTaskOpenDateValid = DateTime.Compare(taskOpenDate, project.OpenDate) >= 0;
                        var isExecutionTypeValid = Enum.TryParse(taskDto.ExecutionType, out ExecutionType executionType);
                        var isLabelTypeValid = Enum.TryParse(taskDto.LabelType, out LabelType labelType);
                        var isTaskDueDateValid = true;

                        if (project.DueDate != null)
                        {
                            isTaskDueDateValid = DateTime.Compare(taskDueDate,
                                DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)) < 0;
                        }
                        
                        var isTaskValid = IsValid(taskDto) &&
                                          isTaskOpenDateValid &&
                                          isTaskDueDateValid &&
                                          isExecutionTypeValid &&
                                          isLabelTypeValid &&
                                          isTaskOpenDateValidFormat &&
                                          isTaskDueDateValidFormat;

                        if (isTaskValid)
                        {
                            var task = new Task
                            {
                                Name = taskDto.Name,
                                OpenDate = taskOpenDate,
                                DueDate = taskDueDate,
                                ExecutionType = executionType,
                                LabelType = labelType
                            };

                            project.Tasks.Add(task);
                        }
                        else
                        {
                            result.AppendLine(ErrorMessage);
                        }
                    }

                    validProjects.Add(project);

                    result.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                }
                else
                {
                    result.AppendLine(ErrorMessage);
                }
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();
            List<Employee> validEmployees = new List<Employee>();

            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            foreach (var employeeDto in employeesDto)
            {
                var isValid = IsValid(employeeDto);

                var tasks = employeeDto.Tasks;

                if (isValid)
                {
                    var employee = new Employee()
                    {
                        Username = employeeDto.Username,
                        Email = employeeDto.Email,
                        Phone = employeeDto.Phone
                    };

                    foreach (var taskId in tasks.Distinct())
                    {
                        var currentTask = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                        if (currentTask != null)
                        {
                            EmployeeTask employeeTask = new EmployeeTask()
                            {
                                TaskId = taskId
                            };

                            employee.EmployeesTasks.Add(employeeTask);
                        }
                        else
                        {
                            result.AppendLine(ErrorMessage);
                        }
                    }

                    validEmployees.Add(employee);

                    result.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
                }
                else
                {
                    result.AppendLine(ErrorMessage);
                }
            }

            context.Employees.AddRange(validEmployees);
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
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}