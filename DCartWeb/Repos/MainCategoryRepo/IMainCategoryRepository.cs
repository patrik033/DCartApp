using DCartWeb.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DCartWeb.Repos.MainCategoryRepo
{
    public interface IMainCategoryRepository
    {
        IEnumerable<MainCategory> GetAll();
        MainCategory GetMainCategoryWithSubCategorys(int? id);
        Task<MainCategory> GetMainCategoryById(int? id);
        Task<int> Delete(int? id);
        Task Create(MainCategory newCategory);
        Task Edit(MainCategory category);
    }
}
