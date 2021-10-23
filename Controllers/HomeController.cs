using EStore.Controllers;
using EStore.Models;
using EStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EStore.Controllers
{




    public class Posted
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

}
public class HomeController : Controller
{
    private readonly IProduct _productRepo;

    private readonly ILogger<HomeController> _logger;

    public HomeController(IProduct productRepo)
    {
        _productRepo = productRepo;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            ProductsOfTheWeek = _productRepo.ProductsOfTheWeek

        };
        return View(homeViewModel);
    }

    public async Task<IActionResult> Privacy()
    {

        HttpClient http = new HttpClient();

        var response = await http.GetAsync("https://jsonplaceholder.typicode.com/posts/");

        var content = response.Content;
        var contentString = await content.ReadAsStringAsync();

        var posts = JsonConvert.DeserializeObject<List<Posted>>(contentString);

        var json =JsonConvert.SerializeObject(posts);
        return View(posts.Take(20));
    }



}

