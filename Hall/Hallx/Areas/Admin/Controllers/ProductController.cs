using Hallx.Domain.Models;
using Hallx.Persistence.RepositoryFolder.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Hallx.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> product = _unitOfWork.ProductRepo.GetAll().ToList();
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
           
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepo.Add(product);
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
        public IActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepo.Update(product);
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
            Product product = _unitOfWork.ProductRepo.GetById(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Product product = _unitOfWork.ProductRepo.GetById(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepo.Delete(product);
            _unitOfWork.Save();
            TempData["Success"] = "Category deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
