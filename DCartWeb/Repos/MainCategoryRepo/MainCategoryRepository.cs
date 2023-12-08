using DCartWeb.Data;
using DCartWeb.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DCartWeb.Repos.MainCategoryRepo
{
    /// <summary>
    /// Used primarely for the test project
    /// </summary>
    public class MainCategoryRepository : IMainCategoryRepository
    {
        private readonly DCartWebContext _context;

        public MainCategoryRepository(DCartWebContext context)
        {
            _context = context;
        }

        public IEnumerable<MainCategory> GetAll()
        {
            var result = _context.MainCategories.AsNoTracking().ToList();
            return result;
        }

        /// <summary>
        /// Return a main category and its subcategory populated
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  MainCategory GetMainCategoryWithSubCategorys(int? id)
        {
            var category =  _context.MainCategories.AsNoTracking().Include(x => x.SubCategories).FirstOrDefault(x => x.Id == id);
            return category;
        }

        public async Task<MainCategory> GetMainCategoryById(int? id)
        {
            var category = await _context.MainCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }



        public async Task Create(MainCategory mainCategory)
        {
            _context.MainCategories.Add(mainCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int? id)
        {
            var category = await GetMainCategoryById(id);
            _context.MainCategories.Remove(category);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task Edit(MainCategory category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
