using System.Linq;
using System.Web.Mvc;
using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;

namespace RestaurantPaymentSystem.Controllers.Menu
{
    public class SubcategoryController : Controller
    {
        readonly IRestaurantPaymentSystemDb _db;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db?.Dispose();
            }
            base.Dispose(disposing);
        }

        public SubcategoryController() : this(new EFRestaurantPaymentSystemDB())
        {

        }

        public SubcategoryController(IRestaurantPaymentSystemDb db)
        {
            _db = db;
        }

        // GET: AllSubcategories
        public ActionResult AllSubcategories()
        {
            var model = _db.GetCategories().OrderBy(c => c.CategoryName);
            return View("AllSubcategories", model);
        }

        public ActionResult GetAllSubcategoriesForCategory(int categoryId)
        {
            if (Request.IsAjaxRequest())
            {
                var model = _db.GetCategory(categoryId).Subcategories;
                return PartialView("_Subcategories", model);
            }

            return HttpNotFound();
        }

        // GET: Subcategory/Create
        public ActionResult Create(int categoryId)
        {
            return View("Create");
        }

        // POST: Subcategory/Create
        [HttpPost]
        public ActionResult Create(Subcategory model)
        {
            if (ModelState.IsValid)
            {
                _db.SaveNewSubcategory(model);
                return AllSubcategories();
            }
            return View("Create");
        }

        // GET: Subcategory/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _db.GetSubcategory(id);
            if (model != null)
            {
                return View("Delete", model);
            }
            return HttpNotFound();
        }

        //??? TODO take a look at authorize action filter
        //??? TODO write tests when trying to delete subcategory with existing items - same with category with existing subcategories
        // POST: Subcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcategory existingSubcategory = _db.GetSubcategory(id);
            var subcategoryExists = existingSubcategory != null;
            if (subcategoryExists)
            {
                var subcategoryHasNoSubcategories = existingSubcategory.Items == null || existingSubcategory.Items.Count == 0;
                if (subcategoryHasNoSubcategories)
                {
                    _db.DeleteSubcategory(existingSubcategory);
                    return AllSubcategories();
                }
            }
            ModelState.AddModelError("", "Subcategory cannot be deleted because it has items. Please delete all items first.");
            return Delete(id);
        }

        // GET: Subcategory/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.GetSubcategory(id);
            if (model != null)
            {
                return View("Details", model);
            }
            return HttpNotFound();
        }

        // GET: Subcategory/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.GetSubcategory(id);
            if (model != null)
            {
                return View("Edit", model);
            }
            return HttpNotFound();
        }

        // POST: Subcategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subcategory model)
        {
            if (ModelState.IsValid)
            {
                var existingSubcategory = _db.GetSubcategory(model.Id);
                var subcategoryExists = existingSubcategory != null;
                if (subcategoryExists)
                {
                    _db.SaveExistingSubcategory(existingSubcategory, model);
                }
                return AllSubcategories();
            }
            return View("Edit");
        }
    }
}