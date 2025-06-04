using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartR.Models;
using ShoppingCartR.Repository;

namespace ShoppingCartR.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        // GET: CategoryController
        public ActionResult Index()
        {
            List<Category> categoryList = _unitOfWork.Category.GetAllexpression().ToList();
                return View(categoryList);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category Category)
        {
            try
            {
                if (Category == null)
                {
                    return RedirectToAction(nameof(Index));
                 }
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.Add(Category);
                    _unitOfWork.Save();
                    TempData["Success"] = "Category created Successfully";
                    return RedirectToAction("Index");
                }
                return View();

                }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var checkCategory =_unitOfWork.Category.Get(x=> x.CategoryId == id);
            if (checkCategory == null)
            { 
                return NotFound(); 
            }       
            return View(checkCategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category Category)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.Update(Category);
                    _unitOfWork.Save();
                    TempData["Success"] = "Category updated Successfully";
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var checkCategory = _unitOfWork.Category.Get(x => x.CategoryId == id);
            if (checkCategory == null)
            {
                return NotFound();
            }
            return View(checkCategory);
        }

        // POST: CategoryController/Delete/5
        [HttpPost , ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletepost(int id)
        {
            try
            {
                var checkCategory = _unitOfWork.Category.Get(x => x.CategoryId == id);
                if (checkCategory == null)
                {
                    return NotFound();
                }
                _unitOfWork.Category.Remove(checkCategory);
                _unitOfWork.Save();
                TempData["Success"] = "Category deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
