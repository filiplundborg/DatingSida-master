using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
    }
}