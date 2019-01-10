using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatingSida.Models
{
    public class Visitors
    {
        [Key]
        public virtual int VisitorsId { get; set; }
        public virtual DateTime DateSent { get; set; }
       

        public virtual string VisitSendId { get; set; }
        public virtual string VisitReceivedId { get; set; }

        [ForeignKey("VisitSendId")]
        [InverseProperty("VisitorsSent")]
        public virtual ApplicationUser VisitSender { get; set; }

        [ForeignKey("VisitReceivedId")]
        [InverseProperty("VisitorsReceived")]
        public virtual ApplicationUser VisitReceiver { get; set; }
    }
}