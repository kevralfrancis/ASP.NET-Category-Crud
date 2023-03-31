using Microsoft.AspNetCore.Mvc;
using PerryPrepareTwo.Data;
using PerryPrepareTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerryPrepareTwo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        //=======================EXAMPLE OF HOW TO RETURN MULTIPLE OBJECT=================================================//

     /*   public class IndexViewModel
        {
            public IEnumerable<Category> Categories { get; set; }
            public IEnumerable<Product> Products { get; set; }
        }


        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories;
            IEnumerable<Product> products = _db.Products;

            IndexViewModel viewModel = new IndexViewModel
            {
                Categories = categories,
                Products = products
            };

            return View(viewModel);
        }
     */
        //=======================EXAMPLE OF HOW TO RETURN MULTIPLE OBJECT END HERE=================================================//





        //This will return a list of the model to the indext page
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }


        //GET ---Tis view will not return any data
        // This will contain a form that will accept data to be submitted
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }



}

