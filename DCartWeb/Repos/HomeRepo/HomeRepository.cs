using DCartWeb.Data;
using DCartWeb.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace DCartWeb.Repos.HomeRepo
{
    /// <summary>
    /// Used primarely for the test project
    /// </summary>
    public class HomeRepo : IHomeRepo
    {
        private readonly DCartWebContext _context;

        public HomeRepo(DCartWebContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            var products = _context.Products.ToList();
            return products;
        }

        /// <summary>
        /// Returns a list of products with the specified sub category as parent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProductList(int? id)
        {
            var products = _context.Products.Where(x => x.SubCategoryId == id).ToList();
            return products;
        }

        /// <summary>
        /// Returns a list of sub categories with the specified main category as parent 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<SubCategory> GetSubCategories(int? id)
        {
            var subCategory = _context.SubCategories.AsNoTracking().Where(x => x.MainCategoryId == id).ToList();
            return subCategory;
        }

        public Product GetProductById(int? id)
        {
            var product = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return product;
        }
        public void CreateProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
    }
}
