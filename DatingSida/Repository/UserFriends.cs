using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Repository
{
    public class UserFriends
    {
        public List<ApplicationUser> WashFriendsData(ApplicationUser user) {
            var friendsRequested = user.FriendsRequested.Select(i => i.FriendReceived).ToList();
            var friendsReceived = user.FriendsReceived.Select(i => i.FriendRequest).ToList();
            var friends = friendsRequested;
            friends.AddRange(friendsReceived);
            return friends;
        }
    }
}