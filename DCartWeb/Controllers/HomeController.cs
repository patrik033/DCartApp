using DCartWeb.Data;
using DCartWeb.LoadIntoUI;
using DCartWeb.Models;
using DCartWeb.Models.Products;
using DCartWeb.Repos.HomeRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DCartWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DCartWebContext _context;
        private readonly IHomeRepo _productContext;
        private readonly ILoadCategories _loadCategories;

        [BindProperty]
        public Product Products { get; set; }



        public HomeController(IHomeRepo context, ILoadCategories loadCategories)
        {
            _productContext = context;
            _loadCategories = loadCategories;
            Products = new Product();
        }

        /// <summary>
        /// Load All Featured Products and populate the view with them
        /// </summary>
        /// <returns></returns>
        /// 
        [ResponseCache(Duration = 500)]
        public IActionResult Index()
        {
            var load = _loadCategories.GetAllFeaturedProducts();
            return View(load);
        }

        /// <summary>
        /// Return a list of SubCategory which has the maincategory as parent
        /// and return that to the view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult SubIndex(int? id)
        {
            var subCategory = _productContext.GetSubCategories(id);
            if (subCategory != null)
                return View(subCategory);
            return BadRequest();
        }


        /// <summary>
        /// Returns a list of products which has the subcategory as parent
        /// , then populates the view with that list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Product(int? id)
        {
            var products = _productContext.GetProductList(id);
            if (products != null)
                return View(products);
            else
                return BadRequest();
        }

        /// <summary>
        /// Returns a product and populates that item to the view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int? id)
        {
            Products = _productContext.GetProductById(id);
            if (Products != null)
                return View(Products);
            return BadRequest();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}