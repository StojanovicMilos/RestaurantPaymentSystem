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
            _db?.Dispose();
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
                var model = _db.GetCategory(categoryId);
                return PartialView("_Subcategories", model);
            }

            return null;//TODO ??? fix
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
            ModelState.AddModelError("", "Category cannot be deleted because it has subcategories. Please delete all subcategories first.");
            return Delete(id);
        }
    }
}