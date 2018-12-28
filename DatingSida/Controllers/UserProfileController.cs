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
            var viewModel = new UserProfileIndexViewModel();

            var user = db.Users.Single(i => i.Id == User.Identity.GetUserId());
            return View(user);
        }
    }
}