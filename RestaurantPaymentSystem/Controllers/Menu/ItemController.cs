using System.Web.Mvc;
using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;

namespace RestaurantPaymentSystem.Controllers.Menu
{
    public class ItemController : Controller
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

        public ItemController() : this(new EFRestaurantPaymentSystemDB()) { }

        public ItemController(IRestaurantPaymentSystemDb db)
        {
            _db = db;
        }

        // GET: AllItems
        public ActionResult AllItems()
        {
            var model = _db.GetCategories();
            return View("AllItems", model);
        }

        public ActionResult GetAllSubcategoryNamesForCategory(int categoryId)
        {
            if (Request.IsAjaxRequest())
            {
                var model = _db.GetCategory(categoryId).Subcategories;
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            return HttpNotFound();
        }

        public ActionResult GetAllItemsForSubcategory(int subcategoryId)
        {
            if (Request.IsAjaxRequest())
            {
                var model = _db.GetSubcategory(subcategoryId).Items;
                return PartialView("_Items", model);
            }

            return HttpNotFound();
        }

        //TODO ??? take a look and implement crud actions as default suggests
        //// GET: Item/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = _db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}

        // GET: Item/Create
        public ActionResult Create(int subcategoryId)
        {
            return View("Create");
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(Item model)
        {
            if (ModelState.IsValid)
            {
                _db.SaveNewItem(model);
                return AllItems();
            }
            return View("Create");
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.GetItem(id);
            if (model != null)
            {
                return View("Details", model);
            }
            return HttpNotFound();
        }


        // GET: Item/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _db.GetItem(id);
            if (model != null)
            {
                return View("Delete", model);
            }
            return HttpNotFound();
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item existingItem = _db.GetItem(id);
            var itemExists = existingItem != null;
            if (itemExists)
            {
                _db.DeleteItem(existingItem);
                return AllItems();
            }

            ModelState.AddModelError("", "Category cannot be deleted because it has subcategories. Please delete all subcategories first.");
            return Delete(id);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.GetItem(id);
            if (model != null)
            {
                return View("Edit", model);
            }
            return HttpNotFound();
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item model)
        {
            if (ModelState.IsValid)
            {
                var existingItem = _db.GetItem(model.Id);
                var itemExists = existingItem != null;
                if (itemExists)
                {
                    _db.SaveExistingItem(existingItem, model);
                }
                return AllItems();
            }
            return View("Edit");
        }

        //// POST: Item/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Price")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Items.Add(item);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(item);
        //}

        //// GET: Item/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = _db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}

        //// POST: Item/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Price")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Entry(item).State = EntityState.Modified;
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);
        //}

        //// GET: Item/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = _db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}

        //// POST: Item/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Item item = _db.Items.Find(id);
        //    _db.Items.Remove(item);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
