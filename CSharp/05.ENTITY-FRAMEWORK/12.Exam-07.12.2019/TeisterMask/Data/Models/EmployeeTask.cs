namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        //•	EmployeeId - integer, Primary Key, foreign key(required)
        //•	Employee -  Employee
        //•	TaskId - integer, Primary Key, foreign key(required)
        //•	Task - Task

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
