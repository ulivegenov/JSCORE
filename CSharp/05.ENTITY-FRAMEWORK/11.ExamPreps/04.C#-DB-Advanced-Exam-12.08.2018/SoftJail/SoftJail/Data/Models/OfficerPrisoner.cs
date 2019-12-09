namespace SoftJail.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OfficerPrisoner
    {
        //•	PrisonerId – integer, Primary Key
        //•	Prisoner – the officer’s prisoner(required)
        //•	OfficerId – integer, Primary Key
        //•	Officer – the prisoner’s officer(required)

        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }

        public int OfficerId { get; set; }

        public Officer Officer { get; set; }
    }
}
