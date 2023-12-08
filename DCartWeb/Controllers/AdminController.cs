using DCartWeb.Data;
using DCartWeb.Models.Orders;
using DCartWeb.Models.Users;
using DCartWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text.Json;
using X.PagedList;

namespace DCartWeb.Controllers
{


    //only users with admin access can get to the admin controller
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly DCartWebContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public IEnumerable<SelectListItem> RoleLists { get; set; }

        public AdminController(DCartWebContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            ViewModels = new UserViewModel();
        }

        [BindProperty]
        public UserViewModel ViewModels { get; set; }
        [BindProperty]
        public string OldRoleId { get; set; }



       /// <summary>
       /// Returns a list of OrderItems grouped by month. 
       /// Selects Month And Price and calculates the total price.
       /// </summary>
       /// <returns></returns>
        public IActionResult Index()
        {

            //var money = _context.OrderItems
            //    .GroupBy(x => new { x.DateAdded.Value.Month})
            //    .Select(x => new AveragePrice{ Month = x.Key.Month, Price = x.Average(y => y.Price * y.QuantityInCart) }).ToList();

            //AveragePrice Models.ViewModels
            //Just a class containing two properties
            var money = _context.OrderItems
                .GroupBy(x => new { x.DateAdded.Value.Month })
                .Select(x => new AveragePrice { Month = x.Key.Month, Price = x.Sum(y => y.Price * y.QuantityInCart) }).AsNoTracking().ToList();

            return View(money);
        }

        /// <summary>
        /// Displays all orders, ordered by the date they were added
        /// </summary>
        /// <returns></returns>
        public IActionResult Orders(/*int? page = 1*/)
        {
            //Setup for pagination
            //PageSize = number of items displayed on every page
            //Page = starting page
            var order = _context.Orders.Include(x => x.OrderItem).OrderBy(x => x.DateAdded).AsNoTracking().ToList();
   
            //var pageSize = 15;
            //var order = _context.Orders.Include(x => x.OrderItem).OrderBy(x => x.DateAdded).AsNoTracking().ToPagedList(page?? 1,pageSize);

            return View(order);
        }

        /// <summary>
        /// Displays what the order is containing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OrderResults(int? id)
        {

            if (id != null)
            {
                var orders = _context.OrderItems.Where(x => x.CartId == id).AsNoTracking().ToList();
                return View(orders);
            }
            return NoContent();
        }

        /// <summary>
        /// Load every user except for the currently loged in user
        /// </summary>
        /// <returns></returns>
        public IActionResult Users()
        {
            var users = User.Identity.Name;
            var user = _context.Users.AsNoTracking().Where(x => x.UserName != users).ToList();
            return View(user);
        }

        /// <summary>
        /// Populates the view with a populated UserViewModel for the current user and a Select List Item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ChangeRole(string? id)
        {
            if (id != null)
            {
                var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
                var allRoles = _context.Roles.AsNoTracking().ToList();
                var roles = RoleLists;

                var roleUser = _context.UserRoles.AsNoTracking().FirstOrDefault(x => x.UserId == user.Id);
                var roleId = roleUser.RoleId;

                var roleName = _context.Roles.AsNoTracking().FirstOrDefault(x => x.Id == roleId);

                var model = new UserViewModel
                {
                    OldRole = roleName.Name,
                    User = user,
                    RoleList = _context.Roles.AsNoTracking().ToList().Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    })
                };
                return View(model);
            }
            return View();
        }

        /// <summary>
        /// Updates the role for the selected user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UserViewModel viewModel)
        {
            if (viewModel != null)
            {
                //get current user
                var user = _context.Users.FirstOrDefault(x => x.Id == viewModel.User.Id);
                var userId = user.Id;

                //get old role name
                var oldName = _context.Roles.AsNoTracking().FirstOrDefault(x => x.Name == viewModel.OldRole);
                var oldRoleName = oldName.Name;

                //get updated name
                var newName = _context.Roles.AsNoTracking().FirstOrDefault(x => x.Id == viewModel.Roles.Id);
                var newRoleName = newName.Name;

                //remove and add the roles
                var remove = await _userManager.RemoveFromRoleAsync(user, oldRoleName);
                var add = await _userManager.AddToRoleAsync(user, newRoleName);
            }
            return RedirectToAction("Users","Admin");
        }

        public IActionResult GetAllUsers()
        {
            var userList = _context.Users.AsNoTracking().ToList();
            return View(userList);
        }

        public IActionResult GetSelectedUser(string id)
        {
            var currentUser = _context.Users.Include(x => x.Address).AsNoTracking().FirstOrDefault(x => x.Id == id);
            return View(currentUser);
        }


        /// <summary>
        /// Returns json from order items grouped by their names, select the name and the quantity
        /// </summary>
        /// <returns></returns>

        public JsonResult Charts()
        {

            var data = from a in _context.OrderItems
                        group a by a.Name into grp
                        select new
                        {
                            label = grp.Key,
                            y = grp.Sum(x => x.QuantityInCart)
                        };
            return Json(data);
        }

        /// <summary>
        /// Returns the count for every order items and passes them to the view
        /// </summary>
        /// <returns></returns>
     
        public IActionResult ChartsView()
        { 
            var data = _context.OrderItems.AsNoTracking().Sum(x => x.QuantityInCart);
            return View(data);
        }

        /// <summary>
        /// Returns json grouped by name and select the name and the total price for each order item.
        /// </summary>
        /// <returns></returns>

        public JsonResult ChartsPrice()
        {
            var data = from a in _context.OrderItems
                       group a by a.Name into grp
                       select new
                       {
                           label = grp.Key,
                           y = grp.Sum(x => x.Price * x.QuantityInCart)
                       };
            return Json(data);
        }

        /// <summary>
        /// Returns the total price for all products to the view
        /// </summary>
        /// <returns></returns>
      
        public IActionResult ChartsPriceView()
        {
            var totalIncome = _context.OrderItems.AsNoTracking().Sum(x => x.Price * x.QuantityInCart);
            return View(totalIncome);
        }
    }


}
