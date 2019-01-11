using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Models.ViewModel
{
    public class SearchViewModel
    {
        public string Image { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string InterestedIn { get; set; }
        public string DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}