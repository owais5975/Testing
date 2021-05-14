using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class UsersController : Controller
    {
        LoginDB3Entities db = new LoginDB3Entities();
        public ActionResult Users(string Search)
        {
            if (Search != null)
            {
                var data = db.Users.Where(model => model.Username.StartsWith(Search) || model.Email.StartsWith(Search) ||  model.Role.StartsWith(Search)).ToList();
                return View(data);
            }
            else
            {
                var data = db.Users.ToList();
                return View(data);
            }
        }
        public ActionResult Update(int id)
        {
            var data = db.Users.Where(model => model.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(User user)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(user).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.Success2 = "<script>alert('Update Succussful!!!')</script>";
                }
                else
                {
                    ViewBag.Success2 = "<script>alert('Update Unsuccussful!!!')</script>";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var row2 = db.Users.Where(model => model.Id == id).FirstOrDefault();
                if (row2 != null)
                {
                    db.Entry(row2).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.Success3 = "<script>alert('Delete Succussful!!!')</script>";
                    }
                    else
                    {
                        ViewBag.Success3 = "<script>alert('Delete Unsuccussful!!!')</script>";
                    }

                }
            }
            return RedirectToAction("Users", "Users");
        }
    }
}