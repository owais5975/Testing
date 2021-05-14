using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Testing.Models;

namespace Testing.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LoginDB3Entities db = new LoginDB3Entities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var data = db.Users.Where(model => model.Email == user.Email && model.Password == user.Password).ToList();
            var credentials = db.Users.Where(model => model.Email == user.Email && model.Password == user.Password).FirstOrDefault();
            if(credentials != null)
            {
                if(data.FirstOrDefault().Role == "Admin")
                {
                    TempData["Greet"] = "1";

                    Session["GreetMessage"] = "Welcome Admin";

                }
                Session["Usename"] = data.FirstOrDefault().Username;
                FormsAuthentication.SetAuthCookie(user.Email, false);

                return RedirectToAction("Home", "Home");
            }
            else
            {
                if(user.Email != null && user.Password != null)
                {
                    ViewBag.Error = true;
                    ViewBag.ErrorMessage = "Email / Password is Incorrect";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Login");
        }
    }
}