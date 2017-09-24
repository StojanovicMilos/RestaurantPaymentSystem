using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantPaymentSystem.Models;

namespace A11_RBS.Controllers
{
    [Authorize(Roles="Administrator")]
    public class RoleController : Controller
    {
        ApplicationDbContext _applicationDbContext;

        public RoleController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }



        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var Roles = _applicationDbContext.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _applicationDbContext.Roles.Add(Role);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}