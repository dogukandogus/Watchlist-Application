using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models;
using MovieMVC.Models.ViewModels;

namespace MovieMVC.Controllers
{
    public class CategoryController : Controller
    {
        MovieContext context;
        public CategoryController(MovieContext _context)
        {
            context = _context;
        }
        CategoryVM categoryVModel = new CategoryVM();
        public IActionResult CategoryList()
        {
            categoryVModel.cList = context.Categories.ToList();
            return View(categoryVModel);
        }
        public IActionResult CreateCategory()
        {
            categoryVModel.cList = context.Categories.ToList();
            return View(categoryVModel);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryVM categoryVModel)
        {
            context.Categories.Add(categoryVModel.Category);
            context.SaveChanges();
            TempData["result"] = "A new category named " + categoryVModel.Category.CategoryName + " has been added!";
            return RedirectToAction("CategoryList");
        }
        public IActionResult EditCategory(int id)
        {
            categoryVModel.Category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View(categoryVModel);
        }

        [HttpPost]
        public IActionResult EditCategory(int id, CategoryVM categoryVModel)
        {
            Category category = context.Categories.Find(id);
            category.CategoryName = categoryVModel.Category.CategoryName;
            category.Description = categoryVModel.Category.Description;
            context.SaveChanges();
            TempData["result"] = "The category successfully updated!";
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            TempData["result"] = "The category deleted!";
            return RedirectToAction("CategoryList");
        }

    }
}
