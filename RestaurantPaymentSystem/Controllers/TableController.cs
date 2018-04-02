using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;
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
            return View("alltables", model);
        }

        // GET: Table/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.GetTableByID(id);
            return View("details", model);
        }

        // GET: Table/Create
        public ActionResult Create()
        {
            return View("create");
        }

        // POST: Table/Create
        [HttpPost]
        public ActionResult Create(TableViewModel table)
        {
            if (!ModelState.IsValid)
            {
                return View("create", table);
            }
            _db.CreateNewTable(table);
            return AllTables();
        }

        // GET: Table/Delete/5
        public ActionResult Delete(int id)
        {
            return View("delete");
        }

        // POST: Table/Delete/5
        [HttpPost]
        public ActionResult Delete(TableViewModel table)
        {
            var tableExists = _db.GetTableByID(table.ID) != null;
            var tableHasNoOrders = true; //TODO add logic later
            if (tableExists && tableHasNoOrders)
            {
                _db.DeleteTable(table.ID);
                return AllTables();
            }
            return HttpNotFound();
        }
    }
}
