using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class SystemUserDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public byte[]? Image { get; set; }

        public int Age { get; set; }

        public string? SSN { get; set; }
        public int PaymentMethodId { get; set; }
        public int PlanId { get; set; }

        public decimal? Balance { get; set; }

    }

}