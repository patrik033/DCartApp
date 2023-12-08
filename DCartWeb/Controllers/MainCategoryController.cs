using DCartWeb.Data;
using DCartWeb.Models.Products;
using DCartWeb.Repos.MainCategoryRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Stripe;

namespace DCartWeb.Controllers
{
    public class MainCategoryController : Controller
    {
        private readonly DCartWebContext _context;
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MainCategory MainCategories { get; set; }

        public MainCategoryController(IMainCategoryRepository mainCategoryRepository,DCartWebContext context, IWebHostEnvironment hostEnvironment)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _context = context;
            _hostEnvironment = hostEnvironment;
            MainCategories = new MainCategory();
        }
        public IActionResult Index()
        {
            IEnumerable<MainCategory> getAllMainCategories = _mainCategoryRepository.GetAll();
            if (getAllMainCategories != null)
            {
                return View(getAllMainCategories);
            }
            else
            {
                return View();
            }
        }
        //GET
        public IActionResult Create()
        {
            return View(MainCategories);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MainCategory newCategory)
        {
            if (ModelState.IsValid)
            {
                //returns wwwroot path
                var rootPath = _hostEnvironment.WebRootPath;
                //get all files for the request from the form
                var files = HttpContext.Request.Form.Files;
                //if there's any files
                if (files.Count > 0)
                {
                    //create a new guid for identifier
                    string newFileName = Guid.NewGuid().ToString();
                    //combine the wwwroot path with the path where the file will be stored
                    var uploads = Path.Combine(rootPath, @"Images\Categories");
                    //get the file extension
                    var extension = Path.GetExtension(files[0].FileName);

                    //combine the path for the stored file with the new identifier and extension
                    using (var filestream = new FileStream(Path.Combine(uploads, newFileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    //posterImageUrl = path + new guid + file extension
                    newCategory.PosterImageUrl = @"Images/Categories/" + newFileName + extension;

                }
                await _mainCategoryRepository.Create(newCategory);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newCategory);
            }
        }

        //GET
        public IActionResult View(int? id)
        {
            var category = _mainCategoryRepository.GetMainCategoryWithSubCategorys(id);
            if (category == null)
                return NotFound();
            return View(category);
        }


        //GET
        public async Task<IActionResult> DeleteView(int? id)
        {
                var category = await _context.MainCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(MainCategory mainCategory)
        {
            if (mainCategory == null)
                return NotFound();
            else
            {
                //TODO: check why not everything is returned
                //returns a maincategory based on the id
                var productFromDB = _context.MainCategories.FirstOrDefault(x => x.Id == mainCategory.Id);

                //get the wwwroot path
                var rootPath = _hostEnvironment.WebRootPath;
                //oldPath = wwwroot + the PosterImageURl from db - '/'
                var oldPath = Path.Combine(rootPath, productFromDB.PosterImageUrl.TrimStart('/'));
                //if any file exist at the oldpath it will be removed
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                _context.MainCategories.Remove(productFromDB).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

        }

        //GET
        public IActionResult EditView(int? id)
        {
            var category = _mainCategoryRepository.GetMainCategoryWithSubCategorys(id);
            if (category == null)
                return NotFound();
            else
                return View(category);
        }



        

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MainCategory category)
        {
            if (ModelState.IsValid)
            {

                //get the file contained in the form for the request
                var files = HttpContext.Request.Form.Files;
                //if there's any files
                if(files.Count > 0)
                {
                    //creates a new identifier
                    string newFileName = Guid.NewGuid().ToString();
                    //get the wwwroot
                    var rootPath = _hostEnvironment.WebRootPath;
                    //combine wwwrooot with the path the file will be saved to
                    var upload = Path.Combine(rootPath, @"Images\Categories");
                    //get the extension for the file
                    var extension = Path.GetExtension(files[0].FileName);

                    //combine wwwroot path with the posterImageUrl  - '/'
                    var oldPath = Path.Combine(rootPath, category.PosterImageUrl.TrimStart('/'));
                    //if any file with that name exists it will be deleted
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }

                    //combine the new path + new filename and extension to a new file
                    using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    //posterImageUrl = path + newfilename + extension
                    category.PosterImageUrl = @"Images/Categories/" + newFileName + extension;
                }
                //if there's no file in the request the current file will be the same
                else
                {
                    category.PosterImageUrl = category.PosterImageUrl;
                }


                _context.MainCategories.Update(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }


    }
}
