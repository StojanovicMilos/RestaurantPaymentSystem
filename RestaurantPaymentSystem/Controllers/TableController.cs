using RestaurantPaymentSystem.DB;
using System.Web.Mvc;

namespace RestaurantPaymentSystem.Controllers
{
    public class TableController : Controller
    {
        IRestaurantPaymentSystemDB _db;

        public TableController() : this(new EFRestaurantPaymentSystemDB())
        {

        }

        public TableController(IRestaurantPaymentSystemDB db)
        {
            _db = db;
        }

        // GET: Table
        public ActionResult AllTables()
        {
            var model = _db.GetTables();
            return View(model);
        }

        // GET: Table/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Table/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Table/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
