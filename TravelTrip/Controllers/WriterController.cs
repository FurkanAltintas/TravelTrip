using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class WriterController : Controller
    {
        Context db = new Context();
        BlogWriter bw = new BlogWriter();
        // GET: Writer
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                HttpNotFound();
            }

            var info = db.Writers.Find(id);

            ViewBag.NameSurname = info.Name + " " + info.SurName;

            if (info == null)
            {
                HttpNotFound();
            }

            bw.Blog = db.Blogs.Where(x => x.WriterID == id).ToList();
            bw.Writers = db.Writers.Where(x => x.ID == id).ToList();
            return View(bw);
        }
    }
}