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
            try
            {
                var user = userprofile.GetUserByName(username);
                var list = user.RequestReceived;
                var optionlist = new List<RequestOptions>();
                foreach (var item in list)
                {
                    var requestOption = new RequestOptions
                    {
                        Request = item
                    };
                    optionlist.Add(requestOption);
                }
                return optionlist;
            }
            catch {
                return null;
            }
        }

        public bool HasRequest (string userId, string username)
        {
     
            var model = new UserMessageViewModel();
            var user = userprofile.GetUserByName(username);

            var result = from i in db.Requests
                         where userId == i.RequestSenderId && user.Id == i.RequestReceiverId || userId == i.RequestReceiverId && user.Id == i.RequestSenderId
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

        public bool IsFriends(string userId, string username)
        {

            var model = new UserMessageViewModel();
            var user = userprofile.GetUserByName(username);

            var result = from i in db.Friends
                         where userId == i.UserId && user.Id == i.FriendId || userId == i.FriendId && user.Id == i.UserId
                         select i.FriendId;


            if (result.Count() > 0)
            {
                model.IsFriends = true;
                return true;
            }
            else
            {
                model.IsFriends = false;
                return false;
            }
        }

        public string Match(string userId, string visitedUser)
        {
            var myuser = userprofile.GetUser(userId);
            var model = new UserMessageViewModel();
            var user = userprofile.GetUserByName(visitedUser);
            var random = new Random();
            

            var myage = DateTime.Now.Year - Convert.ToDateTime(myuser.DateOfBirth).Year;

            var yourAge = DateTime.Now.Year - Convert.ToDateTime(user.DateOfBirth).Year;


            if(myuser.Gender == "Man" && user.InterestedIn == "Kvinnor" || myuser.Gender == "Kvinna" && user.InterestedIn == "Män")
            {
                model.Match = "0";
            }

            if(myuser.Gender == "Man" && user.InterestedIn == "Män" && myuser.InterestedIn == "Män" || myuser.Gender == "Man" && user.InterestedIn == "Båda")
            {
                if(myage - yourAge <= 5 && myage - yourAge  > 0 || yourAge - myage <= 5 && yourAge - myage > 0)
                {
                    return model.Match = random.Next(75, 100).ToString();
                }

                if(myage - yourAge <= 10 && myage - yourAge > 0 || yourAge - myage <= 10 && yourAge - myage > 0)
                {
                    return model.Match = random.Next(45, 75).ToString();
                }

                if(myage - yourAge <= 20 && myage - yourAge > 0 || yourAge - myage <= 20 && yourAge - myage > 0)
                {
                    return model.Match = random.Next(30, 45).ToString();
                }
                else
                {
                    return model.Match = random.Next(0, 30).ToString();
                }
            }

            if(myuser.Gender == "Kvinna" && user.InterestedIn == "Kvinnor" && myuser.InterestedIn == "Kvinnor" || myuser.Gender == "Kvinna" && user.InterestedIn == "Båda")
            {
                if (myage - yourAge <= 5 && myage - yourAge > 0 || yourAge - myage <= 5 && yourAge - myage > 0)
                {
                    return model.Match = random.Next(75, 100).ToString();
                }

                if (myage - yourAge <= 10 && myage - yourAge > 0 || yourAge - myage <= 10 && yourAge - myage > 0)
                {
                    return model.Match = random.Next(45, 75).ToString();
                }

                if (myage - yourAge <= 20 && myage - yourAge > 0 || yourAge - myage <= 20 && yourAge - myage > 0)
                {
                    return model.Match = random.Next(30, 45).ToString();
                }
                else
                {
                    return model.Match = random.Next(0, 30).ToString();
                }
            }

            else
            {
                return model.Match = "0";
            }

            

        }

        public string SearchMatch(string userId, string visitedUser)
        {
            var myuser = userprofile.GetUser(userId);
            
            var user = userprofile.GetUserByName(visitedUser);
            var random = new Random();

         
                var myage = DateTime.Now.Year - Convert.ToDateTime(myuser.DateOfBirth).Year;

                var yourAge = DateTime.Now.Year - Convert.ToDateTime(user.DateOfBirth).Year;


                if (myuser.Gender == "Man" && user.InterestedIn == "Kvinnor" || myuser.Gender == "Kvinna" && user.InterestedIn == "Män")
                {
                    return "0";
                }

                if (myuser.Gender == "Man" && user.InterestedIn == "Män" && myuser.InterestedIn == "Män" || myuser.Gender == "Man" && user.InterestedIn == "Båda")
                {
                    if (myage - yourAge <= 5 && myage - yourAge > 0 || yourAge - myage <= 5 && yourAge - myage > 0)
                    {
                        return  random.Next(75, 100).ToString();
                    }

                    if (myage - yourAge <= 10 && myage - yourAge > 0 || yourAge - myage <= 10 && yourAge - myage > 0)
                    {
                        return random.Next(45, 75).ToString();
                    }

                    if (myage - yourAge <= 20 && myage - yourAge > 0 || yourAge - myage <= 20 && yourAge - myage > 0)
                    {
                        return random.Next(30, 45).ToString();
                    }
                    else
                    {
                        return random.Next(0, 30).ToString();
                    }
                }

                if (myuser.Gender == "Kvinna" && user.InterestedIn == "Kvinnor" && myuser.InterestedIn == "Kvinnor" || myuser.Gender == "Kvinna" && user.InterestedIn == "Båda")
                {
                    if (myage - yourAge <= 5 && myage - yourAge > 0 || yourAge - myage <= 5 && yourAge - myage > 0)
                    {
                        return random.Next(75, 100).ToString();
                    }

                    if (myage - yourAge <= 10 && myage - yourAge > 0 || yourAge - myage <= 10 && yourAge - myage > 0)
                    {
                        return random.Next(45, 75).ToString();
                    }

                    if (myage - yourAge <= 20 && myage - yourAge > 0 || yourAge - myage <= 20 && yourAge - myage > 0)
                    {
                        return random.Next(30, 45).ToString();
                    }
                    else
                    {
                        return random.Next(0, 30).ToString();
                    }
                }

                else
                {
                    return "0";
                }
            
            



        }


    }
}