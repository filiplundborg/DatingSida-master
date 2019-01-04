using DatingSida.Models;
using DatingSida.Models.ViewModel;
using DatingSida.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingSida.Controllers
{
    public class SearchController : Controller
    {
        public UserProfile profile = new UserProfile();
        // GET: Search
        public ActionResult Index()
        {
            var allUsers = new AllUsersProfilesViewModel();
            allUsers.Users = profile.GetAllUsers(User.Identity.GetUserName());
            return View(allUsers);
        }

        [HttpGet]
        public ActionResult ViewProfile(string username) {
            if (username != null) { 
            var user = profile.GetUserByName(username);
            var model = new UserProfileIndexViewModel {
                Username = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Description = user.Description,
                Image = user.Image,
                Messages = user.MessageReceived as List<Message>
            };
            return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}