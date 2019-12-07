namespace TeisterMask.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        //•	Id - integer, Primary Key
        //•	Name - text with length[2, 40] (required)
        //•	OpenDate - date and time(required)
        //•	DueDate - date and time(can be null)
        //•	Tasks - collection of type Task

        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
