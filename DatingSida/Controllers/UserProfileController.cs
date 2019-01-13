using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using DatingSida.Repository;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Web.Security;
using System.Net;

namespace DatingSida.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
       
        public ApplicationUserManager UserManager;

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
                Gender = user.Gender,
                InsterestedIn = user.InterestedIn,
                DateOfBirth = user.DateOfBirth,
                Messages = user.MessageReceived as List<Message>,
                MessagesSent = user.MessageSent as List<Message>
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



        [HttpGet]
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

            if(user.InterestedIn == "Män")
            {
                model.InterestedIn = InterestedIn.Män;
            }

            else if(user.InterestedIn == "Kvinnor")
            {
                model.InterestedIn = InterestedIn.Kvinnor;
            }

            else if(user.InterestedIn == "Båda")
            {
                model.InterestedIn = InterestedIn.Båda;
            }


            
            model.Firstname = user.Firstname;
            model.Lastname = user.Lastname;
            model.Username = user.UserName;
            model.Description = user.Description;
            model.Email = user.Email;
            model.DateOfBirth = Convert.ToDateTime(user.DateOfBirth);

            return View(model);
        }



        [HttpPost]
        public ActionResult EditProfile(EditUserProfileViewModel model)
        {
            var profile = new UserProfile();
            var userId = User.Identity.GetUserId().ToString();
            var user = profile.GetUser(userId);
            
            


            if (ModelState.IsValid)
            {
                if (model.Firstname != user.Firstname)
                {
                    user.Firstname = model.Firstname;

                }

                 if (model.Lastname != user.Lastname)
                {
                    user.Lastname = model.Lastname;

                }

                if (model.Username != user.UserName)
                {
                    user.UserName = model.Username;

                }

                if (model.Description != user.Description)
                {
                    user.Description = model.Description;
                }

                if (model.Email != user.Email)
                {
                    user.Email = model.Email;
                }

                 if (model.Gender == Gender.Kvinna)
                {
                    if (user.Gender != "Kvinna")
                    {
                        user.Gender = "Kvinna";
                    }
                }

                 if (model.Gender == Gender.Man)
                {
                    if (user.Gender != "Man")
                    {
                        user.Gender = "Man";
                    }
                }

                 if(model.InterestedIn == InterestedIn.Män)
                {
                    if(user.InterestedIn != "Män")
                    {
                        user.InterestedIn = "Män";
                    }
                }

                 if(model.InterestedIn == InterestedIn.Kvinnor)
                {
                    if(user.InterestedIn != "Kvinnor")
                    {
                        user.InterestedIn = "Kvinnor";
                    }
                }

                 if(model.InterestedIn == InterestedIn.Båda)
                 {
                    if(user.InterestedIn != "Båda")
                    {
                        user.InterestedIn = "Båda";
                    }
                 }

                 if(model.DateOfBirth.ToString() != user.DateOfBirth)
                {
                    user.DateOfBirth = model.DateOfBirth.ToString();
                }



                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
            
        }
        
        public ActionResult SerializeProfile() {
            try
            {
                var user = profile.GetUser(User.Identity.GetUserId());
                var viewModel = new UserProfileIndexViewModel
                {
                    Username = user.UserName,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Gender = user.Gender,
                    Image = user.Image,
                    InsterestedIn = user.InterestedIn,
                    DateOfBirth = user.DateOfBirth,
                    Description = user.Description,

                    Messages = user.MessageReceived as List<Message>,
                    MessagesSent = user.MessageSent as List<Message>
                };

                
                string file = User.Identity.GetUserName().ToString()+ "'" + ".xml";
                string fp = Path.Combine(Server.MapPath("~/ProfilesXml/"), file);
                profile.CheckIfFileExists(fp);
                var serializer = new XmlSerializer(typeof(UserProfileIndexViewModel));
                using (var writer = new StreamWriter(fp))
                {
                    serializer.Serialize(writer, viewModel);
                    writer.Flush();
                }
               
                return RedirectToAction("EditProfile");
            }
            catch (Exception e) {
                
                return RedirectToAction("Index");
            }
        }

        

        public ActionResult ManageFriends()
        {
            var user = profile.GetUser(User.Identity.GetUserId());
            var userfriend = new UserFriends();

            var viewModel = new UserProfileIndexViewModel
            {
                Username = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Image = user.Image,
                Description = user.Description,
                Messages = user.MessageReceived as List<Message>,
                MessagesSent = user.MessageSent as List<Message>,
                Friends = userfriend.WashFriendsData(user),
                Categories = user.Categories as List<Category>
                
            };
            return View(viewModel);
        }

        public ActionResult FriendCategory(int id) {
            var usercategory = new UserCategory();
            var model = usercategory.FillModel(User.Identity.GetUserId(), id);
            return View(model);
        }


    }
}
