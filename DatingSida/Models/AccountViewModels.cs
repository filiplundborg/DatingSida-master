using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DatingSida.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

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

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
