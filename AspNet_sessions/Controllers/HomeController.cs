using AspNet_sessions.Attributes;
using System.Web.Mvc;


namespace AspNet_sessions.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {

            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [Auth]
        public ActionResult Courses()
        {

            return View();
        }

        [Auth]
        public ActionResult Instructor()
        {

            return View();
        }


        public ActionResult Elements()
        {

            return View();
        }


        public ActionResult Blog()
        {

            return View();
        }


        public ActionResult Blog_details()
        {

            return View();
        }


        [Auth]
        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}