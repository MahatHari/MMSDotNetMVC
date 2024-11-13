using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0.01, double.MaxValue)]
        public double? Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? Quantity { get; set; }

        public Category? Category { get; set; }
    }

}