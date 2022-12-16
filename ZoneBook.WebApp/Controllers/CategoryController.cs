using Microsoft.AspNetCore.Mvc;
using ZoneBook.WebApp.Controllers.Add;
using ZoneBook.WebApp.Models;

namespace ZoneBook.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList=_dbContext.Categories;
            return View(objCategoryList);
        }
    }
}
