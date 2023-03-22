using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class CreateProductsViewModel
    {
        [Required(ErrorMessage = "The name cannot be empty")]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long.")]
        [MaxLength(80, ErrorMessage = "The name must be a maximum of 80 characters.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "The description cannot be empty")]
        [MinLength(10, ErrorMessage = "The description must be at least 10 characters long.")]
        [MaxLength(180, ErrorMessage = "The description must be a maximum of 180 characters.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "The price cannot be empty")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "The Image cannot be empty")]
        public string ImageUrl { get; set; }


        [Required(ErrorMessage = "The Category cannot be empty")]
        [MinLength(10, ErrorMessage = "The Category must be at least 10 characters long.")]
        [MaxLength(180, ErrorMessage = "The Category must be a maximum of 180 characters.")]
        public string Category { get; set; }
    }
}
