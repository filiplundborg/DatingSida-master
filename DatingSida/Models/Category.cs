using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatingSida.Models
{
    public class Category
    {
        [Key]
        public virtual int CategoryId { get; set; }
        public virtual string Name { get; set; }

        public virtual string Id { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Friends> Friends { get; set; }
    }
}