using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Models.ViewModel
{
    public class FriendCategoryViewModel
    {
        public Category Category { get; set; }
        public List<ApplicationUser> Friends {get; set;}
    }
}