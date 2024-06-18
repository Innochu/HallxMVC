using Hallx.Domain.Models;
using Hallx.Domain.ViewModel;
using Hallx.Persistence.RepositoryFolder.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ProductVM productVM = new()
            {
                       CategoryList = _unitOfWork.CategoryRepo.GetAll().Select(item => new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString()
                    }),
                        Product = new Product()
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepo.Add(obj.Product);
                _unitOfWork.Save();
                TempData["Success"] = "Product Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unitOfWork.CategoryRepo.GetAll().Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
                         return View(obj);
            }

           
        }
        public IActionResult Edit(int id)
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

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepo.Update(product);
                _unitOfWork.Save();
                TempData["Success"] = "Product Updated Successfully";
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
            TempData["Success"] = "Product deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
