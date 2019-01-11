using DatingSida.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Collections;
using System.Web.Caching;
using System.IO;
using DatingSida.Models.ViewModel;

namespace DatingSida.Repository
{
    public class UserProfile
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationUser GetUser(string userId) {
            var user = db.Users.Single(i => i.Id == userId);
            return user;
        }
        public ApplicationUser GetUserByName(string username)
        {
            var user = db.Users.Single(i => i.UserName == username);
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
        public void ClearCacheItems()
        {
            List<string> keys = new List<string>();
            var cache = new Cache();
            IDictionaryEnumerator enumerator = cache.GetEnumerator();

            while (enumerator.MoveNext())
                keys.Add(enumerator.Key.ToString());

            for (int i = 0; i < keys.Count; i++)
                cache.Remove(keys[i]);
        }
        public void CheckIfFileExists(string path) {
            if (File.Exists(path)) {
                File.Delete(path);
            }
           
        }

        public List<SearchViewModel> GetSearchUsers(string currentUsername)
        {
            
            var users = db.Users.ToList();
            var user = users.Find(i => i.UserName == currentUsername);
            users.Remove(user);

            var list = new List<SearchViewModel>();
            foreach (var u in users)
            {
                if (u.IsActive == true)
                {

                    list.Add(new SearchViewModel
                    {
                        UserName = u.UserName,
                        Image = u.Image,
                        Firstname = u.Firstname,
                        Lastname = u.Lastname,
                        Gender = u.Gender,
                        DateOfBirth = u.DateOfBirth,
                        InterestedIn = u.InterestedIn,
                        Description = u.Description,
                        IsActive = u.IsActive
                        
                    });

                }
            }

            return list;
            
        }

    }
}