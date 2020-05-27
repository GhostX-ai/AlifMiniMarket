using Microsoft.AspNetCore.Mvc;
using AlifAdminMiniMarketV2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AlifAdminMiniMarketV2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            using (DataContext _context = new DataContext())
            {
                var li = _context.Products.OrderByDescending(p => p).Include(p => p.ProductCategory).ToList();
                return View(li);
            }
        }
    }
}