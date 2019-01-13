using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace DatingSida.Models
{
    


    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nuvarande lösenord")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lösenordet {0} måste vara minst {2} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nytt lösenord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta nytt lösenord")]
        [Compare("NewPassword", ErrorMessage = "Lösenorden matchar inte varandra")]
        public string ConfirmPassword { get; set; }
    }
    
}