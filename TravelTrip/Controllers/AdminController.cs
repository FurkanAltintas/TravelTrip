using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Controllers
{
    public class AdminController : Controller
    {
        Context db = new Context();
        // GET: Admin

        #region Admin
        public ActionResult Index()
        {
            var blog = db.Blogs.Count();
            var writer = db.Writers.Count();
            var comments = db.Comments.Count();
            var category = db.Categories.Where(x => x.Status == true).Count();

            ViewBag.blog = blog;
            ViewBag.writer = writer;
            ViewBag.comments = comments;
            ViewBag.category = category;

            var comment = db.Comments.ToList();
            return View(comment);
        }
        #endregion

        #region Slider
        [HttpGet]
        public ActionResult Slider()
        {
            var info = db.Sliders.ToList();
            return View(info);
        }

        public ActionResult SliderDetails(int? id)
        {
            if (id == null)
            {

            }
            var slider = db.Sliders.Find(id);
            if (slider == null)
            {

            }
            return View(slider);
        }

        [HttpGet]
        public ActionResult SliderUpdate(int? id)
        {
            if (id == null)
            {

            }

            var info = db.Sliders.Find(id);

            if (info == null)
            {

            }
            return View(info);
        }

        [HttpPost]
        public ActionResult SliderUpdate(int id, Sliders sliders)
        {
            var info = db.Sliders.Find(id);

            if (ModelState.IsValid)
            {
                info.Hood = sliders.Hood;
                info.SubTitle = sliders.SubTitle;
                info.Image = info.Image;
                db.SaveChanges();
                return RedirectToAction("Slider");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult SliderAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SliderAdd(Sliders sliders)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    string address = "~/Image/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(address));
                    sliders.Image = "/Image/" + fileName + extension;
                    db.Sliders.Add(sliders);
                    db.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            else
            {
                ViewBag.Error = "Görsel Eklemeden İşlem Yapamazsınız";
                return View(sliders);
            }
            return View();

        }

        [HttpGet]
        public ActionResult SliderDelete(int? id)
        {
            if (id == null)
            {

            }
            var info = db.Sliders.Find(id);
            if (info == null)
            {

            }
            return View(info);
        }

        [HttpPost]
        public ActionResult SliderDelete(int id)
        {
            var info = db.Sliders.Find(id);
            db.Sliders.Remove(info);
            db.SaveChanges();
            return RedirectToAction("Slider", "Admin");
        }
        #endregion

        #region Blog
        [HttpGet]
        public ActionResult Blog()
        {
            var info = db.Blogs.Where(x => x.Status == true).ToList();
            return View(info);
        }

        public ActionResult BlogDetails(int? id)
        {
            if (id == null)
            {

            }
            var blogs = db.Blogs.Find(id);
            if (blogs == null)
            {

            }
            return View(blogs);
        }

        [HttpGet]
        public ActionResult BlogUpdate(int? id)
        {
            if (id == null)
            {

            }

            var blogs = db.Blogs.Find(id);

            if (blogs == null)
            {

            }

            return View(blogs);
        }

        [HttpPost]
        public ActionResult BlogUpdate(int id, Blogs blogs)
        {
            var info = db.Blogs.Find(id);
            info.Hood = blogs.Hood;
            info.Explanation = blogs.Explanation;
            info.Image = blogs.Image;
            info.Date = DateTime.Now;
            blogs.WriterID = info.WriterID;
            blogs.Status = true;
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult BlogAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BlogAdd(Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blogs);
                db.SaveChanges();
                return RedirectToAction("Blog", "Admin");
            }
            else
            {
                ViewBag.Error = "Görsel Eklemeden İşlem Yapamazsınız";
                return View(blogs);
            }
        }

        [HttpGet]
        public ActionResult BlogDelete(int? id)
        {
            if (id == null)
            {

            }
            var info = db.Blogs.Find(id);
            if (info == null)
            {

            }
            return View(info);
        }

        [HttpPost]
        public ActionResult BlogDelete(int id)
        {
            var info = db.Blogs.Find(id);
            info.Status = false;
            db.SaveChanges();
            return RedirectToAction("Blog", "Admin");
        }
        #endregion

        #region Footer
        public ActionResult Footer()
        {
            var footer = db.Footers.ToList();
            return View(footer);
        }

        public ActionResult FooterDetails(int? id)
        {
            if (id == null)
            {

            }

            var info = db.Footers.Find(id);

            if (info == null)
            {

            }
            return View(info);
        }

        [HttpGet]
        public ActionResult FooterUpdate(int? id)
        {
            if (id == null)
            {

            }

            var info = db.Footers.Find(id);

            if (info == null)
            {

            }

            return View(info);
        }

        [HttpPost]
        public ActionResult FooterUpdate(int id, Footers footers)
        {
            var info = db.Footers.Find(id);

            if (ModelState.IsValid)
            {
                if (footers.Image == null)
                {
                    footers.Image = info.Image;
                }
                info.Hood = footers.Hood;
                info.Explanation = footers.Explanation;
                info.Image = footers.Image;
                db.SaveChanges();
                return RedirectToAction("Footer");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult FooterAdd(Footers footer)
        {
            if (ModelState.IsValid)
            {
                db.Footers.Add(footer);
                db.SaveChanges();
                return RedirectToAction("Footer");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult FooterDelete(int? id)
        {
            if (id == null)
            {
            }

            var info = db.Footers.Find(id);

            if (info == null)
            {
            }

            db.Footers.Remove(info);
            db.SaveChanges();
            return View();
        }
        #endregion

        #region AboutUs
        public ActionResult Aboutus()
        {
            var info = db.AboutUs.ToList();
            return View(info);
        }

        public ActionResult AboutUsDetail(int? id)
        {
            if (id == null)
            {
            }

            var info = db.AboutUs.Find(id);

            if (info == null)
            {
            }
            return View(info);
        }

        [HttpGet]
        public ActionResult AboutUsAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AboutUsAdd(AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                db.AboutUs.Add(aboutUs);
                db.SaveChanges();
                return RedirectToAction("AboutUs");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AboutUsDelete(int? id)
        {
            if (id == null)
            {
            }

            var info = db.AboutUs.Find(id);

            if (info == null)
            {
            }

            db.AboutUs.Remove(info);
            db.SaveChanges();
            return View();
        }
        #endregion

        #region Contact
        public ActionResult Contact()
        {
            var info = db.Contacts.ToList();
            return View(info);
        }

        public ActionResult ContactDetail(int? id)
        {
            if (id == null)
            {
            }

            var contact = db.Contacts.Find(id);

            if (contact == null)
            {
            }
            return View(contact);
        }

        [HttpGet]
        public ActionResult ContactAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactAdd(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult ContactDelete(int? id)
        {
            if (id == null)
            {
            }

            var info = db.Contacts.Find(id);

            if (info == null)
            {
            }

            db.Contacts.Remove(info);
            db.SaveChanges();
            return RedirectToAction("Contact");
        }
        #endregion

        #region Advertisement
        //public ActionResult Advertisement()
        //{
        //    var advertisement = db.Advertisement.ToList();
        //    return View(advertisement);
        //}

        //public ActionResult AdvertisementDetail(int? id)
        //{
        //    if (id == null)
        //    {
        //    }

        //    var info = db.Advertisement.Find(id);

        //    if (info == null)
        //    {
        //    }

        //    return View(info);
        //}

        //[HttpGet]
        //public ActionResult AdvertisementAdd()
        //{
        //}

        //[HttpPost]
        //public ActionResult AdvertisementAdd(Advertisements advertisement)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Advertisements.Add(advertisement);
        //        db.SaveChanges();
        //        return redirectToAction("Advertisement");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public ActionResult AdvertisementDelete(int? id)
        //{
        //    if (id == null)
        //    {
        //    }

        //    var info = db.Advertisement.Find(id);

        //    if (info == null)
        //    {
        //    }

        //    db.Advertisement.Remove(info);
        //    db.SaveChanges();
        //    return redirectToAction("Advertisement");
        //}
        #endregion

        #region Writer
        public ActionResult Writer()
        {
            var info = db.Writers.ToList();
            return View(info);
        }

        public ActionResult WriterDetail(int? id)
        {
            if (id == null)
            {
            }

            var info = db.Writers.Find(id);

            var blog = db.Blogs.Where(x => x.WriterID == id && x.Status == true).ToList();

            ViewBag.Image = info.Image;

            if (info == null)
            {
            }

            return View(blog);
        }

        public ActionResult WriterComment(int? id)
        {
            if (id == null)
            {

            }

            var info = db.Writers.Find(id);

            var blog = db.Blogs.Where(x => x.WriterID == id).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterAdd(Writers writer)
        {
            if (ModelState.IsValid)
            {
                db.Writers.Add(writer);
                db.SaveChanges();
                return RedirectToAction("Writer");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult WriterDelete(int? id)
        {
            if (id == null)
            {
            }

            var info = db.Writers.Find(id);

            if (info == null)
            {
            }

            db.Writers.Remove(info);
            db.SaveChanges();
            return RedirectToAction("Writer");
        }
        #endregion

        #region Category
        public ActionResult Category()
        {
            var info = db.Categories.ToList();
            return View(info);
        }

        public ActionResult CategoryDetail(int? id)
        {
            if (id == null)
            {
            }

            var info = db.Categories.Find(id);

            if (info == null)
            {
            }

            return View(info);
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int? id)
        {
            if (id == null)
            {

            }

            var info = db.Categories.Find(id);

            if (info == null)
            {

            }

            return View(info);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(int id, Categories categories)
        {
            var info = db.Categories.Find(id);

            info.Hood = categories.Hood;
            info.Explanation = categories.Explanation;
            info.Status = true;
            categories.Date = info.Date;
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Categories category)
        {
            if (ModelState.IsValid)
            {
                category.Status = true;
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Category");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CategoryDelete(int? id)
        {
            if (id == null)
            {
            }

            var info = db.Categories.Find(id);

                var blog = db.Blogs.Where(x => x.CategoriesID == id).ToList();
                ViewBag.blog = blog;

            if (info == null)
            {
            }

            return View(ViewBag.blog);

        }

        [HttpPost]
        public ActionResult CategoryDelete(int id)
        {
            var info = db.Categories.Find(id);

            if (info == null)
            {
            }

            var blog = db.Blogs.Where(x => x.CategoriesID == id).ToList();
            foreach (var item in blog)
            {
                db.Blogs.Remove(item);
                db.SaveChanges();
            }

            db.Categories.Remove(info);
            db.SaveChanges();
            return View();
        }
        #endregion

        #region Visitor
        //public ActionResult Visitor(Visitor visitor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        visitor.UserName = "Ziyaretçi";
        //        db.Visitor.Add(visitor);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //    }
        //    return View();
        //}
        #endregion

        #region Guest
        //public ActionResult Guest()
        //{
        //    var info = db.Guest.ToList();
        //    return View(info);
        //}

        //[HttpPost]
        //public ActionResult GuestDelete(int id)
        //{
        //    var info = db.Guest.Find(id);

        //    if (info == null)
        //    {
        //    }

        //    db.Guest.Remove(info);
        //    db.SaveChanges();
        //    return View();
        //}
        #endregion

        public ActionResult Comment()
        {
            var comment = db.Comments.ToList();
            return View(comment);
        }

        public ActionResult CommentActive(int id)
        {
            var comment = db.Comments.Find(id);

            if (comment == null)
            {

            }

            if (comment.status == true)
            {
                comment.status = false;
            }
            else
            {
                comment.status = true;
            }
            db.SaveChanges();
            return RedirectToAction("Comment");
        }
    }
}