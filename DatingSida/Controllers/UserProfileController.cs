using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using DatingSida.Repository;



namespace DatingSida.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public UserProfile profile = new UserProfile();

        // GET: UserProfile
        public ActionResult Index()
        {
            var user = profile.GetUser(User.Identity.GetUserId());

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
                //för att göra sökvägen helt unik används GUID
                string pic = Guid.NewGuid().ToString() + "_" + Path.GetFileName(img.FileName);

                string imgPath = Path.Combine(Server.MapPath("~/Images/"), pic);
                img.SaveAs(imgPath);
                var profileImagePath = @"Images\" + pic;

                //Hämtar användaren, vi borde dock göra en statisk metod som returnerar användaren då denna kommer att användas ofta.
                var user = profile.GetUser(User.Identity.GetUserId());
                profile.SaveImagePath(profileImagePath, User.Identity.GetUserId());              
            }
           

            return RedirectToAction("Index");
        }


        public ActionResult EditProfile()
        {
            var model = new EditUserProfileViewModel();
            var profile = new UserProfile();
            var userId = User.Identity.GetUserId().ToString();
            var user = profile.GetUser(userId);

          

            if(user.Gender == "Man") {
                model.Gender = Gender.Man;
            }

            else if(user.Gender == "Kvinna")
            {
                model.Gender = Gender.Kvinna;
            }
            
            

            model.Firstname = user.Firstname;
            model.Lastname = user.Lastname;
            model.Username = user.UserName;
            model.Description = user.Description;
            model.Email = user.Email;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(EditUserProfileViewModel model)
        {   if (0 < 2)
            {
                var user = User.Identity.GetUserName();
                model.Username = user;
                return RedirectToAction("Index");
            }

            else
            {
                return View(model);
            }
        }
    }
}