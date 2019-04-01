using System.Linq;
using System.Web.Mvc;
using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;

namespace RestaurantPaymentSystem.Controllers.Menu
{
    //TODO change all return AllCategories(); to redirecttoaction
    public class CategoryController : Controller
    {
        private readonly IRestaurantPaymentSystemDb _db;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db?.Dispose();
            }
            base.Dispose(disposing);
        }

        public CategoryController() : this(new EFRestaurantPaymentSystemDB())
        {

        }

        public CategoryController(IRestaurantPaymentSystemDb db)
        {
            _db = db;
        }

        // GET: AllCategories
        public ActionResult AllCategories()
        {
            var model = _db.GetCategories();
            return View("AllCategories", model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.GetCategory(id);
            if (model != null)
            {
                return View("Details", model);
            }
            return HttpNotFound();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _db.SaveNewCategory(model);
                return AllCategories();
            }
            return View("Create");
        }

        // GET: Category/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _db.GetCategory(id);
            if (model != null)
            {
                return View("Delete", model);
            }
            return HttpNotFound();
        }

        //??? TODO take a look at authorize action filter

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var existingCategory = _db.GetCategory(id);
            var categoryExists = existingCategory != null;
            if (categoryExists)
            {
                var categoryHasNoSubcategories = existingCategory.Subcategories == null || existingCategory.Subcategories.Count == 0;
                if (categoryHasNoSubcategories)
                {
                    _db.DeleteCategory(existingCategory);
                    return AllCategories();
                }
            }
            ModelState.AddModelError("", "Category cannot be deleted because it has subcategories. Please delete all subcategories first.");
            return Delete(id);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.GetCategory(id);
            if (model != null)
            {
                return View("Edit", model);
            }
            return HttpNotFound();
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = _db.GetCategory(model.Id);
                var categoryExists = existingCategory != null;
                if (categoryExists)
                {
                    _db.SaveExistingCategory(existingCategory, model);
                }
                return AllCategories();
            }
            return View("Edit");
        }

    }
}
