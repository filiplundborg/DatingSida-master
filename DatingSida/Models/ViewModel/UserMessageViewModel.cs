using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatingSida.Models.ViewModel
{
    public class UserMessageViewModel
    {
        public string Firstname { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = @"Images\avatar.png";

        public DateTime DateSent { get; set; }

        [Required]
        [MaxLength(400), MinLength(3)]
        public string Post { get; set; }
        [Required]
        public string SenderId { get; set; }
        [Required]
        public string ReceiverId { get; set; }
        public bool IsFriends { get; set; } = false;

        public List<Message> MessagesReceived { get; set; }

        public UserMessageViewModel()
        {
            MessagesReceived = new List<Message>();
        }
    }
}