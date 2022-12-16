using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZoneBook.WebApp.Data;
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
        //GET
        public IActionResult Create()
        {
           
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match th Name.");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var categoryFromDb = _dbContext.Categories.Find(id);
            //var categoryFromDbFirst = _dbContext.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _dbContext.Categories.SingleOrDefault(u => u.Id == id);
            if(categoryFromDb==null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match th Name.");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "Category update successfully";

                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _dbContext.Categories.Find(id);
            //var categoryFromDbFirst = _dbContext.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _dbContext.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _dbContext.Categories.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Category delete successfully";

            return RedirectToAction("Index");



        }

    }

}


