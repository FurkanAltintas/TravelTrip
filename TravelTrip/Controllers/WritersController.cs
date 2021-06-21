using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class WritersController : Controller
    {
        Context db = new Context();
        // GET: Writers
        public ActionResult Index()
        {
            var writers = db.Writers.Where(x => x.Status == true).ToList();
            return View(writers);
        }
    }
}