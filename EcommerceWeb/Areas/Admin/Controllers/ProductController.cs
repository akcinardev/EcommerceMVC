using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
		public ProductController(IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<Product> products = _productRepo.GetAll().ToList();
            
            return View(products);
        }

        public IActionResult Create()
        {
            ProductVM productVM = new()
            {
                Product = new Product(),

                CategoryList = _categoryRepo.GetAll()
				.Select(c => new SelectListItem
				{
					Text = c.Name,
					Value = c.Id.ToString()
				})
			};

			return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVm)
        {
			if (productVm.Product.CategoryId == 0)
			{
				ModelState.AddModelError("Product.CategoryId", "Category is required.");
			}

			if (ModelState.IsValid)
            {
                _productRepo.Add(productVm.Product);
                _productRepo.Save();
                TempData["success"] = "Product created successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                productVm.CategoryList = _categoryRepo.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    });

				return View(productVm);
			}
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepo.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Update(product);
                _productRepo.Save();
                TempData["success"] = "Product updated successfully!";
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

            var product = _productRepo.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? product = _productRepo.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _productRepo.Remove(product);
            _productRepo.Save();
            TempData["success"] = "Product deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
