using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record ChangePasswordDto
    {
        [Required(ErrorMessage ="Please enter Old password")]
        public string oldPassword { get; set; }

        [Required(ErrorMessage ="Please enter new password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters long and contain at least one lowercase letter, one uppercase letter, one numeric digit, and one non-alphanumeric character.")]
        public string NewPassword { get; set; }

    }
}
