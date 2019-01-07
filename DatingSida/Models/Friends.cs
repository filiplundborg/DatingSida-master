using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatingSida.Models
{
    public class Friends
    {

        public int FriendsID { get; set; }
        public virtual string UserId { get; set; }
        public virtual string FriendId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("FriendsReceived")]
        public virtual ApplicationUser FriendReceived { get; set; }

        [ForeignKey("FriendId")]
        [InverseProperty("FriendsRequested")]
        public virtual ApplicationUser FriendRequest { get; set; }

    }
}