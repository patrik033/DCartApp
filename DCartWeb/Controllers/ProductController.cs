using DCartWeb.Data;
using DCartWeb.Models;
using DCartWeb.Models.Products;
using DCartWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace DCartWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly DCartWebContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductViewModel ViewModels { get; set; }
        public Product Products { get; set; }

        public ProductController(DCartWebContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            ViewModels = new ProductViewModel();
            Products = new Product();
        }
        //Secures the endpoint so only admin roles has access
        /// <summary>
        /// Returns all Products in a paged list. 
        /// PageSize is the maximum number of Products show on a single page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Index(/*int? page = 1*/)
        {
            var pageSize = 4;
            //var product = _context.Products.AsNoTracking().ToPagedList(page ?? 1, pageSize);
            var product = _context.Products.AsNoTracking().ToList();

            return View(product);
        }


        //GET

        public async Task<IActionResult> View(int? id)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return BadRequest();
            return View(product);
        }

        public IActionResult PartialForm()
        {
            var product = _context.Products.AsNoTracking().ToList();

            return View(product);
        }

        //GET
        /// <summary>
        /// Return a view without any layout for Products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> _PartialView(int? id)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return BadRequest();
            return View(product);
        }



        //GET
        /// <summary>
        /// Return a view for the item to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return View(product);
            }
        }


        public async Task<IActionResult> _PartialDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return View(product);
            }
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(Product product)
        {
            if (product == null)
                return BadRequest();
            else
            {
                //TODO: check why not all contents for the Product are returned
                var productFromDB = _context.Products.FirstOrDefault(x => x.Id == product.Id);
                //retrieve the path for the wwwroot
                var rootPath = _hostEnvironment.WebRootPath;
                //combines the wwwroot path with the posterImageUrl
                var oldPath = Path.Combine(rootPath, productFromDB.PosterImageUrl.TrimStart('/'));
                //if oldpath exists it's removed
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                _context.Products.Remove(productFromDB).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }


        [HttpPost]

        public async Task<IActionResult> DeleteJson(int? id)
        {
            if (id == 0)
                return BadRequest();
            else
            {
                //TODO: check why not all contents for the Product are returned
                var productFromDB = _context.Products.FirstOrDefault(x => x.Id == id);
                //retrieve the path for the wwwroot
                var rootPath = _hostEnvironment.WebRootPath;
                //combines the wwwroot path with the posterImageUrl
                var oldPath = Path.Combine(rootPath, productFromDB.PosterImageUrl.TrimStart('/'));
                //if oldpath exists it's removed
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                _context.Products.Remove(productFromDB).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Json(productFromDB);
            }
        }

        //GET
        /// <summary>
        /// Returns a view with all Subcategories populated in a selectlist
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewModels.MainCategoryItems = _context.SubCategories.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
            return View(ViewModels);
        }
        /// <summary>
        /// Return a View without a layout with all SubCategories populated in a selectlist
        /// </summary>
        /// <returns></returns>
        public IActionResult _PartialCreate()
        {
            ViewModels.MainCategoryItems = _context.SubCategories.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
            return View(ViewModels);
        }




       
        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel newProduct)
        {

            if (ModelState.IsValid)
            {
                //return the path for wwwroot
                var rootPath = _hostEnvironment.WebRootPath;
                //return the files for the form for the current request
                var files = HttpContext.Request.Form.Files;
                //if any files exists
                if (files.Count > 0)
                {
                    //creates a new unique guid
                    string newFileName = Guid.NewGuid().ToString();
                    //combine wwwrooth to where the file will be stored
                    var uploads = Path.Combine(rootPath, @"Images\Products");
                    //get the file extension
                    var extension = Path.GetExtension(files[0].FileName);

                    //creates a new filestream and combine the path, filename and
                    //extension to create a new unique path where the file will be stored
                    //sets the mode to create
                    using (var filestream = new FileStream(Path.Combine(uploads, newFileName + extension), FileMode.Create))
                    {
                        //saves the first file to the filestream
                        files[0].CopyTo(filestream);
                    }
                    //sets the posterImageUrl
                    newProduct.Subs.PosterImageUrl = @"Images/Products/" + newFileName + extension;
                }

                _context.Products.Add(newProduct.Subs);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(newProduct);
            }
        }
        /// <summary>
        /// for jquery
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateJson(ProductViewModel newProduct)
        {

            if (ModelState.IsValid)
            {
                //return the path for wwwroot
                var rootPath = _hostEnvironment.WebRootPath;
                //return the files for the form for the current request
                var files = HttpContext.Request.Form.Files;
                //if any files exists
                if (files.Count > 0)
                {
                    //creates a new unique guid
                    string newFileName = Guid.NewGuid().ToString();
                    //combine wwwrooth to where the file will be stored
                    var uploads = Path.Combine(rootPath, @"Images\Products");
                    //get the file extension
                    var extension = Path.GetExtension(files[0].FileName);

                    //creates a new filestream and combine the path, filename and
                    //extension to create a new unique path where the file will be stored
                    //sets the mode to create
                    using (var filestream = new FileStream(Path.Combine(uploads, newFileName + extension), FileMode.Create))
                    {
                        //saves the first file to the filestream
                        files[0].CopyTo(filestream);
                    }
                    //sets the posterImageUrl
                    newProduct.Subs.PosterImageUrl = @"Images/Products/" + newFileName + extension;
                }

                _context.Products.Add(newProduct.Subs);
                 _context.SaveChanges();
                return Json(newProduct.Subs);
            }
            else
            {
                //return PartialView("_PartialCreate", newProduct);
                return View(newProduct.Subs);
            }
        }

        //GET
        /// <summary>
        /// Populates the selectlist with all SubCategories and populates the view with the ViewModel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditView(int? id)
        {
            if (id == null)
                return BadRequest();
            else
            {
                ViewModels.MainCategoryItems = _context.SubCategories.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                });
            }
            //Populated the ViewModels Product with a product based on the id provided
            ViewModels.Subs = _context.Products.FirstOrDefault(x => x.Id == id);
            var subs = ViewModels.Subs;
            if (subs == null)
                return BadRequest();
            else
            {
                return View(ViewModels);
            }
        }

        public IActionResult _PartialEdit(int? id)
        {
            if (id == null)
                return BadRequest();
            else
            {
                ViewModels.MainCategoryItems = _context.SubCategories.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                });
            }
            //Populated the ViewModels Product with a product based on the id provided
            ViewModels.Subs = _context.Products.FirstOrDefault(x => x.Id == id);
            var subs = ViewModels.Subs;
            if (subs == null)
                return BadRequest();
            else
            {
                return View(ViewModels);
            }
        }

        /// <summary>
        /// For jquery
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditJson(ProductViewModel newProduct)
        {
            //TODO: check right model is valid instead
            if (newProduct.Subs != null || newProduct.Subs.Id != 0 || newProduct.Subs.ProductName != null)
            {
                //get the files from the from request
                var files = HttpContext.Request.Form.Files;
                //if theres any files
                if (files.Count > 0)
                {
                    //create a unique identifier
                    string newFileName = Guid.NewGuid().ToString();
                    //get the wwwroot path
                    var rootPath = _hostEnvironment.WebRootPath;
                    //combine the rootpath to where the files will be saved
                    var upload = Path.Combine(rootPath, @"Images\Products");
                    //get the extension for the file
                    var extension = Path.GetExtension(files[0].FileName);

                    //combine wwwroot to where the oldImage is saved and removes the '/' at the start of it
                    var oldPath = Path.Combine(rootPath, newProduct.Subs.PosterImageUrl.TrimStart('/'));
                    //if any file exists at oldpath it will be removed
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    //combines the path with the new name and extension to create a new file at that path
                    using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    //updates the posterImageUrl to the new path
                    newProduct.Subs.PosterImageUrl = @"Images/Products/" + newFileName + extension;
                }

                //if theres no new file sets the current path to posterImageUrl
                else
                {
                    newProduct.Subs.PosterImageUrl = newProduct.Subs.PosterImageUrl;
                }

                _context.Products.Update(newProduct.Subs).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
                return BadRequest(newProduct);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel newProduct)
        {
            //TODO: check right model is valid instead
            if (newProduct.Subs != null || newProduct.Subs.Id != 0 || newProduct.Subs.ProductName != null)
            {
                //get the files from the from request
                var files = HttpContext.Request.Form.Files;
                //if theres any files
                if (files.Count > 0)
                {
                    //create a unique identifier
                    string newFileName = Guid.NewGuid().ToString();
                    //get the wwwroot path
                    var rootPath = _hostEnvironment.WebRootPath;
                    //combine the rootpath to where the files will be saved
                    var upload = Path.Combine(rootPath, @"Images\Products");
                    //get the extension for the file
                    var extension = Path.GetExtension(files[0].FileName);

                    //combine wwwroot to where the oldImage is saved and removes the '/' at the start of it
                    var oldPath = Path.Combine(rootPath, newProduct.Subs.PosterImageUrl.TrimStart('/'));
                    //if any file exists at oldpath it will be removed
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    //combines the path with the new name and extension to create a new file at that path
                    using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    //updates the posterImageUrl to the new path
                    newProduct.Subs.PosterImageUrl = @"Images/Products/" + newFileName + extension;
                }

                //if theres no new file sets the current path to posterImageUrl
                else
                {
                    newProduct.Subs.PosterImageUrl = newProduct.Subs.PosterImageUrl;
                }

                _context.Products.Update(newProduct.Subs).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(newProduct);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
