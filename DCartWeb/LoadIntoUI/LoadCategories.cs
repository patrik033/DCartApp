using DCartWeb.Data;
using DCartWeb.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace DCartWeb.LoadIntoUI
{
    /// <summary>
    /// Used to populate the Home controllers
    /// Index page with the featured products
    /// </summary>
    public class LoadCategories : ILoadCategories
    {
        private readonly DCartWebContext _context;

        public LoadCategories(DCartWebContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Returns a list with the first 4 featured products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Product>  GetAllFeaturedProducts()
        {
            var categories = _context.Products.Where(x => x.IsFeatured).Take(4).AsNoTracking().ToList();
            return categories;
        }
    }
}
