using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;
using System.Web.Mvc;

namespace RestaurantPaymentSystem.Controllers
{
    public class TableController : Controller
    {
        IRestaurantPaymentSystemDB _db;

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Dispose();
            base.Dispose(disposing);
        }

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
            return View("AllTables", model);
        }

        // GET: Table/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.GetTable(id);
            return View("Details", model);
        }

        // GET: Table/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Table/Create
        [HttpPost]
        public ActionResult Create(Table table)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", table);
            }
            _db.SaveNewTable(table);
            return AllTables();
        }

        // GET: Table/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _db.GetTable(id);
            if (model != null)
            {
                return View("Delete", model);
            }
            return HttpNotFound();
        }

        // POST: Table/Delete/5
        [HttpPost]
        public ActionResult Delete(Table table)
        {
            var tableExists = _db.GetTable(table.Id) != null;
            var tableHasNoOrders = true; //TODO add logic later
            if (tableExists && tableHasNoOrders)
            {
                _db.DeleteTable(table);
                return AllTables();
            }
            return HttpNotFound();
        }
    }
}
