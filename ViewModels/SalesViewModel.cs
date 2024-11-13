using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels.Validations;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }
        public int SelectedProductId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();


        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)]
        [SalesViewModel_EnsureProperQuantity]
        public int QuantityToSell { get; set; }
    }
}