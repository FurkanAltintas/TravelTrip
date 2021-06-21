using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class AccountController : Controller
    {
        Context db = new Context();
        // GET: Account

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admins admins)
        {
            var admin = db.Admins.Where(x => x.Email == admins.Email && x.Password == admins.Password && x.Status == true).FirstOrDefault();

            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["nameSurname"] = admin.Name + " " + admin.Surname;
                Session["usernama"] = admin.UserName;
                Session["profile"] = admin.Profile;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Error = "Email veya Şifre Hatalı";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}