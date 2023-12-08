using DCartWeb.Data;
using DCartWeb.Models.Carts;
using DCartWeb.Models.Products;
using DCartWeb.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DCartWeb.Repos.CartRepo
{
    /// <summary>
    /// Used primarely for the test project
    /// </summary>
    public class CartRepo : ICartRepo
    {
        private readonly DCartWebContext _context;

        public CartRepo(DCartWebContext context)
        {
            _context = context;
        }




        public List<Product> GetAllProducts()
        {

            var products = _context.Products.ToList();
            return products;
        }


        /// <summary>
        /// Get all products which is a child of the specified subcategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProductListBySubCategory(int? id)
        {
            var products = _context.Products.Where(x => x.SubCategoryId == id).ToList();
            return products;
        }


        /// <summary>
        /// Get all subcategories which is a child of the specified maincategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<SubCategory> GetSubCategoriesByMainCategory(int? id)
        {
            var subCategory = _context.SubCategories.Where(x => x.MainCategoryId == id).ToList();
            return subCategory;
        }

        public Product GetProductById(int? id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
        public void CreateProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }




        public void SaveCart(Cart cart)
        {
            _context.Add(cart);
            _context.SaveChanges();
        }

        public User GetUserById(string id)
        {
            var userType = _context.Users.FirstOrDefault(x => x.UserName == id);
            return userType;
        }

        /// <summary>
        /// Get the user cart and bring the related cartitems
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cart GetUserCart(string id)
        {
            var cartItems = _context.Carts.Include(x => x.CartItems).Where(x => x.CustomerId.ToString() == id).FirstOrDefault();
            return cartItems;
        }

       

        public CartItem GetCartItemById(int? id)
        {
            return _context.CartItems.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
