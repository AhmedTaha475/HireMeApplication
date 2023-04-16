using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record RegisterFreelancerDto
    {

        [Required(ErrorMessage = "Please Enter First Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must not exceed 20 character and bigger than 5 characters")]
        public string FirstName { get; init; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Last Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must not exceed 20 character and bigger than 5 characters")]
        public string Lastname { get; init; } = string.Empty;
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Pleaes enter your email")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; init; } = string.Empty;

        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9]).{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter and one digit")]
        public string Password { get; init; } = string.Empty;
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; init; } = string.Empty;
    }
}
