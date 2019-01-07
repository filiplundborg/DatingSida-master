using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

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

        [XmlIgnore]
        public List<Message> Messages { get; set; }

        [XmlIgnore]
        public List<Message> MessagesSent { get; set; }
       
        public UserProfileIndexViewModel() {
            Messages = new List<Message>();
            MessagesSent = new List<Message>();
        }
    }
   
}