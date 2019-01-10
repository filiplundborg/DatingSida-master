﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Models
{
    public class UserProfileIndexViewModel
    {
        public string Firstname { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = @"Images\avatar.png";
        public List<Friends> FriendsReceived { get; set; }
        public List<Friends> FriendsRequested { get; set; }
        public List<ApplicationUser> Friends { get; set; }
        public List<Category> Categories { get; set; }

        public List<Message> Messages { get; set; }
        public List<Message> MessagesSent { get; set; }
        public UserProfileIndexViewModel() {
            Messages = new List<Message>();
            MessagesSent = new List<Message>();
            FriendsReceived = new List<Friends>();
            FriendsRequested = new List<Friends>();
            Friends = new List<ApplicationUser>();
            Categories = new List<Category>();
        }
    }
   
}