using DCartWeb.Models.Carts;
using DCartWeb.Models.Products;
using DCartWeb.Models.Users;

namespace DCartWeb.Repos.CartRepo
{
    public interface ICartRepo
    {
        List<Product> GetAllProducts();
        IEnumerable<Product> GetProductListBySubCategory(int? id);
        IEnumerable<SubCategory> GetSubCategoriesByMainCategory(int? id);
        Product GetProductById(int? id);
        void CreateProduct(Product product);

        void SaveCart(Cart cart);
        User GetUserById(string id);
        Cart GetUserCart(string id);
        CartItem GetCartItemById(int? id);
        void UpdateCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);
        void Save();
    }
}
