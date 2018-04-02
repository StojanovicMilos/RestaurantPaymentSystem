using System.Web.Mvc;

namespace RestaurantPaymentSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("about");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("contact");
        }
    }
}