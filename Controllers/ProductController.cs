using Microsoft.AspNetCore.Mvc;
using AlifAdminMiniMarketV2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AlifAdminMiniMarketV2.Controllers
{
    public class ProductController : Controller
    {
        public DataContext _context;
        public ProductController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var li = _context.Products.OrderByDescending(p => p).Include(p => p.ProductCategory).ToList();
            return View(li);
        }
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product model,int id)
        {
            var Category = await _context.Categories.SingleAsync(c=> c.Id == id);
            model.ProductCategory = Category;
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Products.SingleAsync(p=> p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}