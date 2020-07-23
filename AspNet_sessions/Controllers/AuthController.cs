using AspNet_sessions.Context;
using AspNet_sessions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspNet_sessions.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth

        Education db = new Education();
        public ActionResult Index()
        {
            return View();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public ActionResult SignIn(string name, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Name == name);

            if (user != null)
            {
                var isPasswordMatch = Crypto.VerifyHashedPassword(user.Password, password);

                if (isPasswordMatch)
                {
                    Session["login"] = true;
                    Session["userid"] = user.Id;
                    Session["name"] = user.Name;

                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("Email", "Email or password not correct");

            return View("Index");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Signup()
        {
            return View();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
            {
                ModelState.AddModelError("Email", "Email already exist");
            }

            if (db.Users.FirstOrDefault(x => x.Name == user.Name) != null)
            {
                ModelState.AddModelError("Name", "Name already exist");
            }

            if (ModelState.IsValid)
            {
                var hashPassword = Crypto.HashPassword(user.Password);

                user.Password = hashPassword;
                user.ConfirmPassword = hashPassword;

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(user);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}