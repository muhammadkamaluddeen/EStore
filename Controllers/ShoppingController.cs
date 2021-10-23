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

        public ViewResult List()
        {
            var productListViewModel = new ProductListViewModel();
            productListViewModel.Products = _productRepo.AllProducts;

            //foreach (var item in productListViewModel.Products)
            //{
            //    item.Category.CategoryName
            //}


            return View(productListViewModel);
        }

        public IActionResult Detail(int id)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }  
    }
}
