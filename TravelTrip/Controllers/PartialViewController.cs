using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class PartialViewController : Controller
    {
        Context db = new Context();
        // GET: PartialView
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Heading()
        {
            var category = db.Categories.Where(x => x.Status == true).ToList();
            return PartialView(category);
        }

        public PartialViewResult Slider()
        {
            var slider = db.Sliders.ToList();
            return PartialView(slider);
        }

        public PartialViewResult Instagram()
        {
            var instagram = db.Footers.ToList();
            return PartialView(instagram);
        }

        public PartialViewResult Tags()
        {
            var tags = db.Categories.ToList();
            return PartialView(tags);
        }

        public PartialViewResult Subscribe()
        {
            return PartialView();
        }

        public PartialViewResult LatestPosts()
        {
            var info = db.Blogs.OrderByDescending(x => x.ID).Take(4).ToList();
            return PartialView(info);
        }
    }
}