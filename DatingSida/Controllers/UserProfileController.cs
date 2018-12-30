using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;

namespace DatingSida.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserProfile
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            var user = db.Users.Single(i => i.Id == userId);
            var viewModel = new UserProfileIndexViewModel {
                Username = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Image = user.Image,
                Description = user.Description,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SetImage(HttpPostedFileBase img) {
            if (img != null) {
                string pic = Path.GetFileName(img.FileName);
              
                
                string imgPath = Path.Combine(Server.MapPath("~/Images/"), pic);
             
                img.SaveAs(imgPath);

                var fileName = Guid.NewGuid().ToString() + "_" + pic;
                var imagePath = @"Images\" + fileName;
                var userId = User.Identity.GetUserId();
                var user = db.Users.Single(i => i.Id == userId);
                user.Image = imgPath;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}