using Hallx.Domain.Models;
using Hallx.Persistence.RepositoryFolder.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Hallx.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.CategoryRepo.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Order cannot be the same.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepo.Add(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Added Successfully";
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
            Category category = _unitOfWork.CategoryRepo.GetById(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepo.Update(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Updated Successfully";
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
            Category category = _unitOfWork.CategoryRepo.GetById(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category category = _unitOfWork.CategoryRepo.GetById(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepo.Delete(category);
            _unitOfWork.Save();
            TempData["Success"] = "Category deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
