using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class ContactController : Controller
    {
        Context db = new Context();
        // GET: Contact
        public ActionResult Index()
        {
            var contact = db.Contacts.ToList();
            return View(contact);
        }
    }
}