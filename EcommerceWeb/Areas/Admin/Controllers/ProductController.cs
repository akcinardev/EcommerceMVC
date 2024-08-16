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
        private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductController(IProductRepo productRepo, ICategoryRepo categoryRepo, IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> products = _productRepo.GetAll().ToList();
            
            return View(products);
        }

        public IActionResult Upsert(int? id) //Update - Insert
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

            if (id == 0 || id == null)
            {
                // Create New Product
				return View(productVM);
			}
            else
            {
                // Update existing Product
                productVM.Product = _productRepo.Get(u => u.Id == id);
                return View(productVM);
			}
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVm, IFormFile? file)
        {
			if (productVm.Product.CategoryId == 0)
			{
				ModelState.AddModelError("Product.CategoryId", "Category is required.");
			}

			if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVm.Product.ImageUrl = @"\images\product\" + fileName;
                }
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
