using DCartWeb.Models.Products;

namespace DCartWeb.LoadIntoUI
{
    public interface ILoadCategories
    {
        public List<Product> GetAllFeaturedProducts();
    }
}
