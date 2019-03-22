using System.Linq;
using System.Web.Mvc;
using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;

namespace RestaurantPaymentSystem.Controllers.Menu
{
    public class SubcategoryController : Controller
    {
        readonly IRestaurantPaymentSystemDB _db;

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }

        public SubcategoryController() : this(new EFRestaurantPaymentSystemDB())
        {

        }

        public SubcategoryController(IRestaurantPaymentSystemDB db)
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
    }
}