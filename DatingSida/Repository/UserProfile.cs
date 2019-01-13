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

        public ApplicationUser GetUser(string userId)
        {
            var user = db.Users.Single(i => i.Id == userId);
            return user;
        }
        public ApplicationUser GetUserByName(string username)
        {
            try
            {
                var user = db.Users.Single(i => i.UserName == username);
                return user;
            }
            catch {
                return null;
            }
        }
        public void SaveImagePath(string imgPath, string userId)
        {
            var user = this.GetUser(userId);
            user.Image = imgPath;
            db.SaveChanges();
        }
        public List<ApplicationUser> GetAllUsers(string currentUsername)
        {
            var users = db.Users.ToList();

            var user = users.Find(i => i.UserName == currentUsername);
            users.Remove(user);
            return users;
        }
        // Tar bort all lagrad data som webbläsaren har. Körs när en användare tar bort in profil. 
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

        // Kollar om en fil existerar. Om den gör det så tar den bort den. Körs av SerializeXml metoden. 
        public void CheckIfFileExists(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }

        public List<CarouselViewModel> GetRandomUsers()
        {
            var list = new List<CarouselViewModel>();
            var amount = db.Users.Count();
            if (amount >= 3)
            {
                var users = db.Users.Where(i => i.IsActive == true).OrderBy(r => Guid.NewGuid()).Take(3);

                foreach (var item in users)
                {
                    list.Add(new CarouselViewModel
                    {
                        Image = item.Image,
                        Description = item.Description,
                        UserName = item.UserName
                    });
                }

            }
            return list;

        }

        public List<SearchViewModel> GetSearchUsers(string currentUsername)
        {
            var request = new UserRequest();
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
                        IsActive = u.IsActive,
                        Match = request.SearchMatch(user.Id, u.UserName)
                    });

                }
            }

            return list;

        }

        /* 
        Metoden tar in ett användar id.
        Sedan använder den IDt för att ta bort alla gånger som en användare förekommer i någon referenstabell.
        Detta gör alltså att användaren försvinner från andra användares vännlistor, saker som användaren skrivit
        på väggar försvinner etc.
             */
        public void RemoveAllUserReferences(string id)
        {

            var user = GetUser(id);
            db.Requests.RemoveRange(user.RequestReceived);
            db.Requests.RemoveRange(user.RequestSent);
            db.Friends.RemoveRange(user.FriendsReceived);
            db.Friends.RemoveRange(user.FriendsRequested);
            db.Categories.RemoveRange(user.Categories);
            db.Visitors.RemoveRange(user.VisitorsSent);
            db.Visitors.RemoveRange(user.VisitorsReceived);
            db.Messages.RemoveRange(user.MessageReceived);
            db.Messages.RemoveRange(user.MessageSent);
            db.SaveChanges();

        }
    }
}