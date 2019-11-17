namespace FastFood.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryAllViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
