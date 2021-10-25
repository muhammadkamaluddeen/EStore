using EStore.Models;
using EStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IProduct _productRepo;
        private readonly ICategory _categoryRepo;
        public ShoppingController(IProduct productRepo, ICategory categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

     
        public ViewResult List(string category)
        {
            IEnumerable<Product> products;
            string currentCategory;

            // List all 
            if (string.IsNullOrEmpty(category))
            {
                products = _productRepo.AllProducts.OrderBy(p => p.ProductId);
                currentCategory = "All products";
            }
            // List a product category
            else
            {
                products = _productRepo.AllProducts.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.ProductId);
                currentCategory = _categoryRepo.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }
    }
}
