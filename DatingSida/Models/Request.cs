using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatingSida.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        public virtual string RequestSenderId { get; set; }
        public virtual string RequestReceiverId { get; set; }

        [ForeignKey("RequestSenderId")]
        [InverseProperty("RequestSent")]
        public virtual ApplicationUser RequestSender { get; set; }

        [ForeignKey("RequestReceiverId")]
        [InverseProperty("RequestReceived")]
        public virtual ApplicationUser RequestReceiver { get; set; }
    }
}