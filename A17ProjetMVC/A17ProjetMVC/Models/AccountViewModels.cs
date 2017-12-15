using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace A17ProjetMVC.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "modelAccEmail", ResourceType = typeof(Resources.site))]
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

        [Display(Name = "modelAccMemorizePassword", ResourceType = typeof(Resources.site))]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "modelAccEmail", ResourceType = typeof(Resources.site))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "statRegistrationNumber", ResourceType = typeof(Resources.site))]
        public string Matricule { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "modelPassword", ResourceType = typeof(Resources.site))]
        public string Password { get; set; }

        [Display(Name = "modelMemorizePass", ResourceType = typeof(Resources.site))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "modelAccEmail", ResourceType = typeof(Resources.site))]
        public string Email { get; set; }

        [Required]
        [Display(Name = "statRegistrationNumber", ResourceType = typeof(Resources.site))]
        public string Matricule { get; set; }

        [Required]
        [Display(Name = "statLastName", ResourceType = typeof(Resources.site))]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "statFirstName", ResourceType = typeof(Resources.site))]
        public string Prenom { get; set; }

        [Required]
        [Phone]
        [Display(Name = "modelUserTel", ResourceType = typeof(Resources.site))]
        public string NumeroTelephone { get; set; }

        [Required]
        [Display(Name = "modelUserAddress", ResourceType = typeof(Resources.site))]
        public string Adresse { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "modelPassword", ResourceType = typeof(Resources.site))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "modelConfirmPass", ResourceType = typeof(Resources.site))]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "modelAccEmail", ResourceType = typeof(Resources.site))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "modelPass", ResourceType = typeof(Resources.site))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "modelConfirmPass", ResourceType = typeof(Resources.site))]
        [Compare("Password", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "modelAccEmail", ResourceType = typeof(Resources.site))]
        public string Email { get; set; }
    }
}
