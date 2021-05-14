using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    [AllowAnonymous]
    public class SignupController : Controller
    {
        LoginDB3Entities db = new LoginDB3Entities();
        // GET: Signup
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.Success = "<script>alert('Registeration Succussful!!!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Success = "<script>alert('Registered Unsuccussfully!!!')</script>";
                }
            }
            return View();
        }
    }
}