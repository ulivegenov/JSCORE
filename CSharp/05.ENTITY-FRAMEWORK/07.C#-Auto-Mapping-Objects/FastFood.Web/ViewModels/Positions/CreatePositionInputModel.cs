namespace FastFood.Web.ViewModels.Positions
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePositionInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string PositionName { get; set; }
    }
}
