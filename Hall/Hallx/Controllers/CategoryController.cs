using Hallx.Data;
using Hallx.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hallx.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HallxDbContext _hallxDbContext;

        public CategoryController(HallxDbContext hallxDbContext)
        {
            _hallxDbContext = hallxDbContext;
        }
        public IActionResult Index()
        {
            List<Category> categories = _hallxDbContext.Categories.ToList();
            return View(categories);
        }
    } 
}
