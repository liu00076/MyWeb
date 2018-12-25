using System.Web.Mvc;

namespace EmptyMVC.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /User/Home/

        public ActionResult Index()
        {
            ViewBag.StrUrl = Url.Action("Index", new { area = "" });
            return View();
        }

    }
}
