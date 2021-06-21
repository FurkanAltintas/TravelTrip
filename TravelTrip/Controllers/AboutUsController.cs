using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class AboutUsController : Controller
    {
        BlogAboutUs ba = new BlogAboutUs();
        Context db = new Context();
        // GET: AboutUs
        public ActionResult Index()
        {
            ba.AboutUs = db.AboutUs.ToList();
            ba.Blog = db.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(ba);
        }
    }
}