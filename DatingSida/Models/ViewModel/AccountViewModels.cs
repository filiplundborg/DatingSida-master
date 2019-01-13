using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DatingSida.Models
{

    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Användarnamn")]
        [MaxLength(30), MinLength(3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Display(Name = "Kom ihåg mig?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} måste vara minst {2} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Password", ErrorMessage = "Lösenorden måste stämma överens")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Användarnamn")]
        [MaxLength(30), MinLength(3)]
        public string Username { get; set; }
        
        [Required]
        [Display(Name = "Förnamn")]
        [MaxLength(30), MinLength(3)]
        public virtual string Firstname { get; set; }
        
        [Required]
        [Display(Name = "Efternamn")]
        [MaxLength(30), MinLength(3)]
        public virtual string Lastname { get; set; }

        [Required]
        [DisplayName("Födelsedatum")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/DD}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Kön")]
        [Range(1, 2, ErrorMessage = "Du måste välja ett kön")]
        public virtual Gender Gender { get; set; }

        [Required]
        [Display(Name = "Intresserad av")]
        [Range(1, 3, ErrorMessage = "Du måste välja vad du är intresserad av")]
        public virtual InterestedIn InterestedIn { get; set; }


        [Required]
        [Display(Name = "Beskrivning")]
        [StringLength(400, ErrorMessage = "{0} måste vara minst {2} tecken långt.", MinimumLength = 30)]
        public virtual string Description { get; set; }


    }
   
    public enum Gender {
        Man = 1,
        Kvinna = 2
    }

    public enum InterestedIn
    {
        Män = 1,
        Kvinnor = 2,
        Båda = 3
    }

   

  
}
