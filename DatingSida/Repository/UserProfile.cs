using DatingSida.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DatingSida.Repository
{
    public class UserProfile
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationUser GetUser(string userId) {
            var user = db.Users.Single(i => i.Id == userId);
            return user;
        }
        public void SaveImagePath(string imgPath, string userId) {
            var user = this.GetUser(userId);
            user.Image = imgPath;
            db.SaveChanges();
        }
        public List<ApplicationUser> GetAllUsers(string currentUsername) {
            var users = db.Users.ToList();
            var user = users.Find(i => i.UserName == currentUsername);
            users.Remove(user);
            return users;
        }
        
    }
}