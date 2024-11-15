using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;
namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory: true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories(),
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";
            return View(productViewModel);

        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productViewModel = new ProductViewModel
            {
                Product = ProductsRepository.GetProductById(id) ?? new Product(),
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);

        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories = CategoriesRepository.GetCategories();
            ViewBag.Action = "edit";
            return View(productViewModel);

        }
        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCateogryPartial(int CategoryId)
        {

            var products = ProductsRepository.GetProductsByCategoryId(CategoryId);
            return PartialView("_Products", products);
        }
    }
}