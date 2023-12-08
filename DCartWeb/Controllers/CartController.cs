using DCartWeb.Data;
using DCartWeb.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DCartWeb.Models.Carts;
using DCartWeb.Repos.CartRepo;
using DCartWeb.Models.Users;
using System.Security.Policy;

namespace DCartWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepo _context;

        public CartController(ICartRepo context)
        {
            _context = context;

        }

        public IActionResult Index()
        {

            var user = User.Identity.Name;
            if (user != null)
            {

                var userType = _context.GetUserById(user);
                var userId = userType.Id;
                var cartItems = _context.GetUserCart(userId);
                return View(cartItems);
            }
            else
            {
                ModelState.AddModelError("Login Error", "Sorry Something went wrong,try to login");
                return View();
            }
        }
        /// <summary>
        /// Returns only the form of the view
        /// </summary>
        /// <returns></returns>
        public IActionResult LoadPartOfView()
        {
            //get the currently loged in user
            var user = User.Identity.Name;
            if (user != null)
            {
                var userType = _context.GetUserById(user);
                var userId = userType.Id;
                var cartItems = _context.GetUserCart(userId);
                return View(cartItems);
            }
            else
            {
                ModelState.AddModelError("Login Error", "Sorry Something went wrong,try to login");
                return View();
            }
        }




        public IActionResult AddProductToCart(int? id)
        {
            Cart cartReturned = new();
            //Get the product based on the id
            var products = _context.GetProductById(id);

            //get the currently loged in user
            var user = User.Identity.Name;
            if (user != null)
                cartReturned = LogedinUserAddedProduct(cartReturned, products, user);


            if (products != null)
            {

                TempData["Success"] = $"{products.ProductName} Added To Cart";
                return RedirectToAction("Details", "Home", new { id = products.Id });
            }

            return BadRequest();
        }


        /// <summary>
        /// Add a product to the cart from the index page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddToCartFromView(int? id)
        {
            Cart cartReturned = new();

            var products = _context.GetProductById(id);

            //user related stuff
            var user = User.Identity.Name;
            if (user != null)
                cartReturned = LogedinUserAddedProduct(cartReturned, products, user);


            if (products != null)
            {
                TempData["Success"] = $"{products.ProductName} Added To Cart";
                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }
        /// <summary>
        /// Retrieves an item as Json and returns the result as Json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult LookUp(int? id)
        {
            var result = _context.GetCartItemById(id);
            return Json(result);
        }
        /// <summary>
        /// Retrives an item as Json and returns the result as Json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Increase(int? id)
        {

            if (id != null)
            {
                var item = _context.GetCartItemById(id);
                var product = _context.GetProductById(item.ProductId);
                if (item.QuantityInCart + 1 <= product.QuantityInStock)
                {
                    item.QuantityInCart += 1;
                    item.QuantityInStock -= 1;
                    _context.UpdateCartItem(item);
                }
            }

            var items = _context.GetCartItemById(id);
            return Json(items);
        }
        /// <summary>
        /// Decrease an item retrieved as Json and return the result as Json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Decrease(int? id)
        {
            if (id != null)
            {
                var item = _context.GetCartItemById(id);
                var product = _context.GetProductById(item.ProductId);
                if (item.QuantityInCart - 1 > 0)
                {
                    item.QuantityInCart -= 1;
                    item.QuantityInStock += 1;

                    _context.UpdateCartItem(item);
                }
            }
            var items = _context.GetCartItemById(id);
            return Json(items);
        }
        /// <summary>
        /// Retrieve cartItem by an id as Json and returns the result as Json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var item = _context.GetCartItemById(id);
                if (item != null)
                {
                    _context.DeleteCartItem(item);
                }
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Returns a cart for the logged in user, creates one if no exist for the user
        /// </summary>
        /// <param name="cartReturned"></param>
        /// <param name="products"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private Cart LogedinUserAddedProduct(Cart cartReturned, Product? products, string? user)
        {
            var userType = _context.GetUserById(user);
            var userId = userType.Id;
            var email = userType.Email;

            var result = _context.GetUserCart(userId);
            if (result == null)
                cartReturned = NoCartExistLoggedInUser(userId, products, email);
            else
            {
                var listToLoop = result.CartItems;
                cartReturned = ExistingCartForRegisteredUser(products, result, listToLoop);
            }
            return cartReturned;
        }
        /// <summary>
        /// Add a product to the cart
        /// </summary>
        /// <param name="products"></param>
        /// <param name="result"></param>
        /// <param name="listToLoop"></param>
        /// <returns></returns>
        private Cart ExistingCartForRegisteredUser(Product? products, Cart? result, List<CartItem>? listToLoop)
        {

            var getItem = listToLoop.FirstOrDefault(x => x.ProductId == products.Id);
            if (getItem != null && products.QuantityInStock > 0 && getItem.QuantityInCart + 1 < products.QuantityInStock)
            {
                getItem.QuantityInCart += 1;
                getItem.QuantityInStock -= 1;
                _context.UpdateCartItem(getItem);
            }

            else if (getItem == null && products.QuantityInStock > 0)
            {
                CartItem cart = AddNewCartItem(products);

                result.CartItems.Add(cart);
                _context.Save();
            }
            return result;
        }

        private static CartItem AddNewCartItem(Product? products)
        {
            return new CartItem
            {
                Name = products.ProductName,
                PictureUrl = products.PosterImageUrl,
                Price = products.ProductPrice,
                DateAdded = products.DateAdded,
                DateUppdated = products.DateUpdated,
                QuantityInStock = products.QuantityInStock,
                QuantityInCart = 1,
                SubCategoryId = products.SubCategoryId,
                ProductId = products.Id
            };
        }

        private Cart NoCartExistLoggedInUser(string? userId, Product? products, string email)
        {
            var cart = new Cart
            {
                UserEmail = email,
                CustomerId = Guid.Parse(userId),
                DateAdded = DateTime.Now,
                CartItems = new List<CartItem>
                        {
                            new CartItem
                            {
                                Name = products.ProductName,
                                PictureUrl = products.PosterImageUrl,
                                Price = products.ProductPrice,
                                DateAdded = products.DateAdded,
                                DateUppdated = products.DateUpdated,
                                QuantityInStock = products.QuantityInStock -1,
                                QuantityInCart = 1,
                                SubCategoryId = products.SubCategoryId,
                                ProductId=products.Id
                            }
                        },
            };
            foreach (var item in cart.CartItems)
            {
                cart.TotalPrice += item.QuantityInCart * item.Price;
            }
            _context.SaveCart(cart);
            return cart;
        }
    }
}
