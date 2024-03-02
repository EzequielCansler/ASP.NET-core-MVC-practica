using Microsoft.AspNetCore.Mvc;
using NehuenOrg.Models;

namespace NehuenOrg.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }
        
        public IActionResult Edit( int? id)
        {
            ViewBag.Action = "edit";
            var categories = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);

            return View(categories);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int CategoryId) {

            CategoriesRepository.DeleteCategory(CategoryId);

            return RedirectToAction(nameof(Index));
        }
    }
}
