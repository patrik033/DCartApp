using DCartWeb.Models.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DCartWeb.Models.ViewModels
{
    public class SubCategoryViewModel
    {
        public IEnumerable<SelectListItem>? MainCategoryItems { get; set; }
        public SubCategory Subs { get; set; } = new SubCategory();
    }
}
