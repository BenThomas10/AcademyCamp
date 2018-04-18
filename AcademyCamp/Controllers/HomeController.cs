using System.Web.Mvc;

namespace AcademyCamp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //If user is in Admin role redirect to Admin Home
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                return RedirectToAction("Index", "AdminHome");
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Academy Camp";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Academy Camp";
            return View();
        }

    }
}