using DCartWeb.Models.Products;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DCartWeb.Models.ViewModels
{
    public class ProductViewModel
    {
        [ValidateNever]
        public IEnumerable<SelectListItem>? MainCategoryItems { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? IsFeaturesItems { get; set; }

        
        public Product Subs { get; set; } = new Product();
    }
}
