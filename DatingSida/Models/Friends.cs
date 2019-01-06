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
        [Key, Column(Order = 0)]
        [Required]
        public virtual string UserId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public virtual string FriendId { get; set; }

        [ForeignKey("FriendId")]
        [InverseProperty("Friends")]
        public virtual ApplicationUser Friend { get; set; }

    }
}