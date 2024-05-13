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

        public IActionResult Create() 
        {
        return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Order cannot be the same.");
            }
            if(ModelState.IsValid)
            {
                _hallxDbContext.Categories.Add(category);
                _hallxDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
           return View();
        }
        public IActionResult Edit(int id) 
        {
            if (id == 0)
            {
                return NotFound();
            }
            Category category = _hallxDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
        return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
           
            if(ModelState.IsValid)
            {
                _hallxDbContext.Categories.Update(category);
                _hallxDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
           return View();
        }
        public IActionResult Delete(int id) 
        {
            if (id == 0)
            {
                return NotFound();
            }
            Category category = _hallxDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
        return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category category = _hallxDbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
                _hallxDbContext.Categories.Remove(category);
                _hallxDbContext.SaveChanges();
                return RedirectToAction("Index");
        }
    } 
}
