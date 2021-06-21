using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PagedList;
using PagedList.Mvc;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class HomeController : Controller
    {
        BlogAboutUs ba = new BlogAboutUs();
        Context db = new Context();
        // GET: Home
        public ActionResult Index()
        {
            ba.AboutUs = db.AboutUs.ToList();
            ba.Blog = db.Blogs.Take(5).OrderByDescending(x => x.ID).ToList();
            return View(ba);
        }

        [HttpPost]
        public ActionResult Index(Blogs members)
        {
            return View();
        }
    }
}