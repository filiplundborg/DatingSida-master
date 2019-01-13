using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatingSida.Models
{
    public class EditUserProfileViewModel
    {
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "{0} måste vara minst {2} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }


        [StringLength(100, ErrorMessage = "{0} måste vara minst {2} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nytt lösenord")]
        public string newPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("newPassword", ErrorMessage = "Lösenorden måste stämma överens")]
        public string ConfirmPassword { get; set; }

        
        [Display(Name = "Användarnamn")]
        [MaxLength(30), MinLength(3)]
        public string Username { get; set; }

        
        [Display(Name = "Förnamn")]
        [MaxLength(30), MinLength(3)]
        public virtual string Firstname { get; set; }

        
        [Display(Name = "Efternamn")]
        [MaxLength(30), MinLength(3)]
        public virtual string Lastname { get; set; }

        [Required]
        [Display(Name = "Födelsedatum")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/DD}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Kön")]
        [Range(1, 2, ErrorMessage = "Du måste välja ett kön")]
        public virtual Gender Gender { get; set; }

        [Required]
        [Display(Name = "Intresserad av")]
        [Range(1, 3, ErrorMessage = "Du måste välja vad du är intresserad av")]
        public virtual InterestedIn InterestedIn { get; set; }



        [Display(Name = "Beskrivning")]
        [StringLength(400, ErrorMessage = "{0} måste vara minst {2} tecken långt.", MinimumLength = 30)]
        public virtual string Description { get; set; }


    }
    

}
