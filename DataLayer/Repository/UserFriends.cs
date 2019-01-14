using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Repository
{
    public class UserFriends
    {
        //Filtrerar fram de vänner en användare har till en lista av ApplicationsUsers. 
        //Dvs, I listan FriendsRequested vill vi ha det användare som hör till friendsreceived och tvärtom.
        public List<ApplicationUser> WashFriendsData(ApplicationUser user) {
            var friendsRequested = user.FriendsRequested.Select(i => i.FriendReceived).ToList();
            var friendsReceived = user.FriendsReceived.Select(i => i.FriendRequest).ToList();
            var friends = friendsRequested;
            friends.AddRange(friendsReceived);
            return friends;
        }

        //Filtrerar fram vänner efter en viss category. Man skickar in en användare och Category Id som parameter. 
        public List<ApplicationUser> FilterFriendsData(ApplicationUser user, int categoryId)
        {
            var friendsRequested = user.FriendsRequested.Where(i => i.CategoryId == categoryId).Select(i => i.FriendReceived).ToList();
            var friendsReceived = user.FriendsReceived.Where(i => i.CategoryId == categoryId).Select(i => i.FriendRequest).ToList();
            var friends = friendsRequested;
            friends.AddRange(friendsReceived);
            return friends;
        }
    }
}