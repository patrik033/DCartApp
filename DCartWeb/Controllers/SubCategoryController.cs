using DCartWeb.Data;
using DCartWeb.Models.Products;
using DCartWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DCartWeb.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly DCartWebContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public SubCategoryViewModel ViewModels { get; set; }

        public SubCategoryController(DCartWebContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            ViewModels = new SubCategoryViewModel();

        }

        /// <summary>
        /// Returns a list of subcategories and don't track them.
        ///  Populates the model for the view with the list
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var subCategory = _context.SubCategories.AsNoTracking().ToList();
            return View(subCategory);
        }


        //GET
        //Returns a Subcategory with the product list for it populated
        public async Task<IActionResult> View(int? id)
        {
            var category = await _context.SubCategories.Include(x => x.Products).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return BadRequest();
            return View(category);
        }

        //GET
        /// <summary>
        /// Return the view for Create populated with a dropdown for the maincategories
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewModels.MainCategoryItems = _context.MainCategories.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View(ViewModels);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(SubCategoryViewModel newCategory)
        {
            if (ModelState.IsValid)
            {

                //webrootpath is the path to all the static files => wwwrooot
                var rootPath = _hostEnvironment.WebRootPath;
                //get the contents for the file contained in the request form
                var files = HttpContext.Request.Form.Files;
                //if any files exists
                if (files.Count > 0)
                {
                    //create a new unique if for the new file
                    string newFileName = Guid.NewGuid().ToString();
                    //get the new path where the file will be stored
                    var uploads = Path.Combine(rootPath, @"Images\SubCategories");
                    //get the extension for the file
                    var extension = Path.GetExtension(files[0].FileName);

                    //sets the path where the file will be created with absolute path combined with the subpath and the extension
                    //and sets the filemode to be create
                    using (var filestream = new FileStream(Path.Combine(uploads, newFileName + extension), FileMode.Create))
                    {
                        //copy the first file to the filestream
                        files[0].CopyTo(filestream);
                    }
                    //sets the PosterImageUrl to the path
                    newCategory.Subs.PosterImageUrl = @"Images/SubCategories/" + newFileName + extension;
                }
                _context.SubCategories.Add(newCategory.Subs);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(newCategory);
        }

        //GET
        /// <summary>
        /// Return the view for Edit populated with a dropdown for the maincategories
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EditView(int? id)
        {



            if (id == null)
                return BadRequest();
            else
            {
                ViewModels.MainCategoryItems = _context.MainCategories.AsNoTracking().ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                ViewModels.Subs = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);

                //var sub = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
                return View(ViewModels);
            }
        }


 
        public async Task<IActionResult> Edit(SubCategoryViewModel category)
        {
            if (category.Subs == null)
                return BadRequest();
            //Check if the provided model is valid
            if (ModelState.IsValid)
            {
                //get the files from the request form
                var files = HttpContext.Request.Form.Files;
                //if there are any files
                if(files.Count > 0)
                {
                    //genereate a new unique if for the file
                    string newFileName = Guid.NewGuid().ToString();
                    //get the rootpath => wwwrooot
                    var rootPath = _hostEnvironment.WebRootPath;
                    //combine the path with the subcategories path
                    var upload = Path.Combine(rootPath, @"Images\SubCategories");
                    //get the extension for the file
                    var extension = Path.GetExtension(files[0].FileName);

                    //combines the rootpath with the posterimageurl and trim the start from all the '/'
                    var oldPath = Path.Combine(rootPath, category.Subs.PosterImageUrl.TrimStart('/'));
                    //if there's any oldfile existing it removes that from the folder
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    //creates the new file and copies it to the new path
                    using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    //sets the posterimageurl to where the new file was created
                    category.Subs.PosterImageUrl = @"Images/SubCategories/" + newFileName + extension;

                }

                //if no file was created sets the posterimageurl to the current one
                else
                {
                    category.Subs.PosterImageUrl = category.Subs.PosterImageUrl;
                }
                _context.SubCategories.Update(category.Subs).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //if model wasn't valid
            else
            {
                return View(category);
            }
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
                return BadRequest();
            else
            {
                var subs = await _context.SubCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return View(subs);
            }
        }

        //POST
        //TODO: check why some properties are missing
        public async Task<IActionResult> Delete(SubCategory category)
        {
            if (category == null)
                return BadRequest();
            else
            {
                //Returns the correct item from the db
                var productFromDB = _context.SubCategories.FirstOrDefault(x => x.Id == category.Id);
                //get the path to wwwroot
                var rootPath = _hostEnvironment.WebRootPath;

                //combine wwwroot with the posterimageurl and removies all '/' at the beginning
                var oldPath = Path.Combine(rootPath, productFromDB.PosterImageUrl.TrimStart('/'));
                //removes the old file from the path
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }


                _context.Remove(productFromDB).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }



}
