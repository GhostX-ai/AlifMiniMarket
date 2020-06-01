using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlifAdminMiniMarketV2.Models;
using Microsoft.EntityFrameworkCore;

namespace AlifAdminMiniMarketV2.Controllers
{
    public class HomeController : Controller
    {
        public DataContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            this._context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var li = _context.Products.OrderByDescending(p => p).Include(p => p.ProductCategory).ToList();
            return View(li);
        }

        [HttpPost]
        public IActionResult Index(string category)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var li = _context.Products.OrderByDescending(p => p).Include(p => p.ProductCategory).Where(p=> p.ProductCategory.Category == category).ToList();
            if(category == "Все")
                li = _context.Products.OrderByDescending(p=> p).Include(p=> p.ProductCategory).ToList();
            return View(li);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
