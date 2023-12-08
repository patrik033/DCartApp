using DCartWeb.Models.Products;


namespace DCartWeb.Repos.HomeRepo
{
    public interface IHomeRepo
    {
        List<Product> GetAll();
        IEnumerable<Product> GetProductList(int? id);
        IEnumerable<SubCategory> GetSubCategories(int? id);
        Product GetProductById(int? id);
        void CreateProduct(Product product);
    }
}
