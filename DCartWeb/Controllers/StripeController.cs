using AutoMapper;
using DCartWeb.Data;
using DCartWeb.Models.Carts;
using DCartWeb.Models.Orders;
using DCartWeb.Models.Products;
using DCartWeb.Models.Stripe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DCartWeb.Controllers
{
    public class StripeController : Controller
    {
        private readonly DCartWebContext _context;
        private readonly IStripeService _stripeService;
        private readonly IMapper _mapper;

        public StripeController(DCartWebContext context, IStripeService stripeService,IMapper mapper)
        {
            _context = context;
            _stripeService = stripeService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Add the current cart for checkout.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddToStripe(int? id)
        {
            //if the user is not logged in he or she will be redirected to an error page.
            var user = User.Identity.IsAuthenticated;
            if (!user)
            {
                return RedirectToAction("NoOrder", "CheckOut");
            }
            else
            {
                //create a new cart and populates it with the cart retrieved from the db based on the id.
                //all the carts cartitems are also brought in.
                Cart cartList = new Cart();
                if (id != null)
                {
                    var cart = _context.Carts.Include(x => x.CartItems).FirstOrDefault(x => x.Id == id);
                    cartList = cart;
                }
                var session = _stripeService.CreateCheckoutSession(cartList);
                return Redirect(session.Url);
            }
        }

        [HttpPost]
        //TODO: används?
        public ActionResult ContactStripe(Cart item)
        {
            var session = _stripeService.CreateCheckoutSession(item);
            return Redirect(session.Url);
        }

        //If the process was successful
        public async Task<IActionResult> Success()
        {

            
            string firstName, lastName, userId;
            ReturnPlaceHolderVariables(out firstName, out lastName, out userId);
            if (userId != null)
            {
                //if something was returned populates the userContext to the correct user
                var userContext = _context.Users.FirstOrDefault(x => x.Id == userId);
                //first and lastname with the correct first and lastnames
                firstName = userContext.FirstName;
                lastName = userContext.LastName;
            }

            //bring in the cart for the current user populeted with all cartitems
            var cartContext = await _context.Carts.Include(x => x.CartItems).Where(x => x.CustomerId.ToString() == userId).FirstOrDefaultAsync();
            var orderItems = new List<OrderItem>();
            var productItems = new List<Product>();

            if (cartContext != null)
            {

                CreateNewOrderItems(cartContext, orderItems);
                Order order = CreateNewOrder(firstName, lastName, userId, orderItems);
                UpdateProducts(orderItems);
                SavesAnOrder(order);
                RemoveCurrentCart(cartContext);

                if (orderItems.Count >= 1)
                    return View(orderItems);
                else
                    return RedirectToAction("/Failed");
            }
            else
                return NoContent();
        }
        /// <summary>
        /// Returns Placeholdervariables
        /// For FirstName,LastName and retrieves correct userId.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userId"></param>
        private void ReturnPlaceHolderVariables(out string firstName, out string lastName, out string? userId)
        {
            firstName = "";
            lastName = "";
            decimal price = 0M;
            var user = User.Identity.Name;
            var userType = _context.Users.FirstOrDefault(x => x.UserName == user);
            userId = userType.Id;
        }
        /// <summary>
        /// Maps the CartItems from the Cart to new OrderItems and Saves them to a list 
        /// </summary>
        /// <param name="cartContext"></param>
        /// <param name="orderItems"></param>
        private void CreateNewOrderItems(Cart? cartContext, List<OrderItem> orderItems)
        {

            foreach (var item in cartContext.CartItems)
            {
                //using automapper to map an item from cartitem => orderitem
                var convertedToOrder = _mapper.Map<OrderItem>(item);
                orderItems.Add(convertedToOrder);
            }
        }
        /// <summary>
        /// Removes all contents in the current cart
        /// </summary>
        /// <param name="cartContext"></param>
        private void RemoveCurrentCart(Cart? cartContext)
        {
            _context.Remove(cartContext);
            _context.SaveChanges();
        }

        private void SavesAnOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        private static Order CreateNewOrder(string firstName, string lastName, string? userId, List<OrderItem> orderItems)
        {
            return new Order
            {
                UserId = Guid.Parse(userId),
                DateAdded = DateTime.Now,
                OrderItem = orderItems,
                CustomerFirstName = firstName,
                CustomerLastName = lastName,
                State = "Processed",
                TotalAmount = orderItems.Sum(x => x.Price * x.QuantityInCart),
            };
        }

        /// <summary>
        /// If everything is successful the products count contained in the orderlist need to be updated to the correct values
        /// </summary>
        /// <param name="orderItems"></param>
        private void UpdateProducts(List<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
                var productItem = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);
                productItem.QuantityInStock -= item.QuantityInCart;
                _context.Update(productItem);
                _context.SaveChanges();
            }
        }

        public IActionResult Failed()
        {
            return View();
        }
    }
}
