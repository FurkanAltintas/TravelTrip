using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        BlogComment bc = new BlogComment();
        Context db = new Context();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(int? id)
        {
            if (id == null)
            {
                HttpNotFound();
            }

            var info = db.Categories.Find(id);
            ViewBag.Category = info.Hood;

            if (info == null)
            {
                HttpNotFound();
            }

            var blog = db.Blogs.Where(x => x.CategoriesID == id).OrderByDescending(x => x.ID).ToList();
            return View(blog);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            bc.Blog = db.Blogs.Where(x => x.ID == id).ToList();
            bc.Comment = db.Comments.Where(x => x.BlogID == id).ToList();
            var info = db.Blogs.Find(id);
            ViewBag.Hood = info.Hood;
            return View(bc);
        }

        [HttpPost]
        public ActionResult Details(int id, Comments comments, Member member)
        {
            Member m = new Member();
            var info = db.Blogs.Find(id);

            if (ModelState.IsValid)
            {
                comments.BlogID = info.ID;
                comments.status = false;
                comments.Date = DateTime.Now;
                db.Comments.Add(comments);
                m.CommentsID = comments.ID;
                m.name = member.name;
                m.surname = member.surname;
                m.email = member.email;
                m.profile = "/original-master/img/bg-img/avatar-profile-icon-png-3-Transparent-Images.png";
                m.status = true;
                db.Member.Add(m);
                comments.MemberID = m.ID;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            else
            {
                return View(comments);
            }
        }

        public ActionResult LatestPosts()
        {
            var info = db.Blogs.OrderByDescending(x => x.ID).ToList();
            return View(info);
        }
    }
}