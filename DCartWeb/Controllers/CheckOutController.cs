using DCartWeb.Data;
using DCartWeb.Models.Carts;
using DCartWeb.Models.Orders;
using DCartWeb.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DCartWeb.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly DCartWebContext _context;

        public CheckOutController(DCartWebContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

       

        /// <summary>
        /// You can't checkout if you have no orders 
        /// </summary>
        /// <returns></returns>
        public IActionResult NoOrder()
        {
            return View();
        }

       
    }
}
