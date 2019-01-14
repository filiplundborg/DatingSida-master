using DatingSida.Models;
using DatingSida.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DatingSida.Repository
{
    public class UserCategory
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public UserFriends Friends = new UserFriends();
        public UserProfile User = new UserProfile();

        //Lägger till en kategori
        public void SaveCategory(string name, string userId) {
            var userprofile = new UserProfile();
            var user = userprofile.GetUser(userId);
            var categori = new Category
            {
                Name = name,
                Id = userId
            };
            db.Categories.Add(categori);
            db.SaveChanges();
        }

        //Lägger till en vän i en kategori.
        public void SaveFriend(string userId, string currentUser, string categoryId) {

            Friends friend;

            try
            {
                friend = db.Friends.Single(i => i.FriendId == userId && i.UserId == currentUser);
            }
            catch (Exception exc) {
                friend = db.Friends.Single(i => i.FriendId == currentUser && i.UserId == userId);
            }
    
            int categoriesId = int.Parse(categoryId);
            friend.CategoryId = categoriesId;
            db.SaveChanges();
            

        }

        public FriendCategoryViewModel FillModel(string userId, int categoryId) {
            var user = User.GetUser(userId);
            var friends = Friends.FilterFriendsData(user, categoryId);


            var model = new FriendCategoryViewModel
            {
                Category = db.Categories.Find(categoryId),
                Friends = friends
            };

            return model;
        }

        //Kontrollerar att kategorin finns.
        public bool IsCategory(int categoryId) {
            return db.Categories.Any(i => i.CategoryId == categoryId);
        }
    }
}