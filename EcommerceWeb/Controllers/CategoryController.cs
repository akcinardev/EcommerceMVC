using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
			_categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<Category> categories = _categoryRepo.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
			return View();
        }

		public IActionResult Edit(int? id)
		{
			if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepo.Get(u => u.Id == id);
            
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_categoryRepo.Update(category);
				_categoryRepo.Save();
				TempData["success"] = "Category updated successfully!";
				return RedirectToAction("Index");
			}

			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = _categoryRepo.Get(u => u.Id == id);

			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
            Category? category = _categoryRepo.Get(u => u.Id == id);

			if (category == null)
            {
                return NotFound();
            }

            _categoryRepo.Remove(category);
            _categoryRepo.Save();
			TempData["success"] = "Category deleted successfully!";
			return RedirectToAction("Index");
		}
	}
}
