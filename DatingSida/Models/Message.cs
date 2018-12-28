using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatingSida.Models
{
    public class Message
    {
        [Key]
        public virtual int MessageId { get; set; }
        public virtual DateTime DateSent { get; set; }
        public virtual string Post { get; set; }

        public virtual string SenderId { get; set; }
        public virtual string ReceiverId { get; set; }

        [ForeignKey("SenderId")]
        [InverseProperty("MessageSent")]
        public virtual ApplicationUser Sender { get; set; }

        [ForeignKey("ReceiverId")]
        [InverseProperty("MessageReceived")]
        public virtual ApplicationUser Receiver { get; set; }

    }
}