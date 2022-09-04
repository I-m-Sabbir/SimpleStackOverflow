using Microsoft.AspNetCore.Authentication;
using SimpleStackOverflow.Infrastructure.Entities.Membership;
using System.ComponentModel.DataAnnotations;
using SimpleStackOverflow.Membership.Services;
using Microsoft.AspNetCore.Identity;

namespace SimpleStackOverflow.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

        public string? ReturnUrl { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
