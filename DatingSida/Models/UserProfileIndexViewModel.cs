using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Models
{
    public class UserProfileIndexViewModel
    {
        public  string Firstname { get; set; }
        public  string Username { get; set; }
        public  string Lastname { get; set; }
        public  string Gender { get; set; }
        public  string Description { get; set; }
        public string Image { get; set; } = @"Images\avatar.png";
       
    }
}