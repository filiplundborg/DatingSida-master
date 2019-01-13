using DatingSida.Models;
using DatingSida.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using DatingSida.Models;
using System.Collections.Generic;

namespace DatingSida.Repository
{
    public class UserMessage
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public UserMessageViewModel GetUserMessageViewModel(string username) {
           
            var user = db.Users.Single(i => i.UserName == username);
            var userMessageModel = new UserMessageViewModel
            {
                Username = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Image = user.Image,
                Description = user.Description,
                MessagesReceived = user.MessageReceived as List<Message>,
                ReceiverId = user.Id,
                InterestedIn = user.InterestedIn
            };
          
                return userMessageModel;
            
        }

        public void SaveMessage(UserMessageViewModel user) {
            if (user.Post.Length < 3 || user.Post.Length > 400) {
                throw new ArgumentException();
            }
            var message = new Message
            {
                DateSent = user.DateSent,
                ReceiverId = user.ReceiverId,
                SenderId = user.SenderId,
                Post = user.Post
            };
            db.Messages.Add(message);
            db.SaveChanges();

        }
        public void DeleteMessage(int id) {
            try
            {
                var message = db.Messages.Find(id);
                db.Messages.Remove(message);
                db.SaveChanges();
            }
            catch {
                throw new Exception();
            }

        }
    }
}