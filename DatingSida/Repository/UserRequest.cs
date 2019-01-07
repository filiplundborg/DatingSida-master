using DatingSida.Models;
using DatingSida.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Repository
{
    public class UserRequest
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public UserProfile userprofile = new UserProfile();

        public void SaveRequest(string senderId, string receiverId) {
            try
            {
                var request = new Request {
                    RequestSenderId = senderId,
                    RequestReceiverId = receiverId
                };
                
                db.Requests.Add(request);
                db.SaveChanges();

            }
            catch {

                throw new Exception();
            }
        }

        internal List<Request> FillModel(object p)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetFriendRequests(string userId) {
            try
            {
                
                var user = userprofile.GetUser(userId);

                return user.RequestReceived as List<Request>;
            }
            catch {
                throw new Exception();
            }

        }
        public void AnswerRequest(int requestId, bool isAccepted) {
            var request = db.Requests.Single(i => i.RequestId == requestId);
            var receiverRequestId = request.RequestReceiverId;
            var senderRequestId = request.RequestSenderId;

            switch (isAccepted) {
                case true:
                    var friends = new Friends
                    {
                        UserId = senderRequestId,
                        FriendId = receiverRequestId
                    };
                    db.Friends.Add(friends);
                    db.Requests.Remove(request);
                    db.SaveChanges();
                    break;
                default:
                    db.Requests.Remove(request);
                    db.SaveChanges();
                    break;
            }
        }
        public List<RequestOptions> FillModel(string username) {
            var user = userprofile.GetUserByName(username);
            var list = user.RequestReceived;
            var optionlist = new List<RequestOptions>();
            foreach (var item in list) {
                var requestOption = new RequestOptions
                {
                    Request = item
                };
                optionlist.Add(requestOption);
            }
            return optionlist;
        }

        public bool HasRequest (string userId, string username)
        {
     
            var model = new UserMessageViewModel();
            var user = userprofile.GetUserByName(username);

            var result = from i in db.Requests
                         where userId == i.RequestSenderId && user.Id == i.RequestReceiverId
                         select i.RequestId;
           

            if (result.Count() > 0)
            {
                model.HasRequest = true;
                return true;
            }
            else
            {
                model.HasRequest = false;
                return false;
            }
        }

    }
}