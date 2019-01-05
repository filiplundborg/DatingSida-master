﻿using DatingSida.Models;
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
    [Authorize]
    public class SearchController : Controller
    {
        public UserProfile profile = new UserProfile();
        public UserMessage profileWithMessage = new UserMessage();

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
               var user = profileWithMessage.GetUserMessageViewModel(username);
        
            return View(user);
            }
            return RedirectToAction("Index");
        }
    }
}