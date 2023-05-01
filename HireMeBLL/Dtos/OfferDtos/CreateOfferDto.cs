using HireMeDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record CreateOfferDto
    {
        [Required(ErrorMessage ="Please Enter your full name")]
        public string Fullname { get; init; }

        [Required(ErrorMessage ="Please enter your email")]
        [EmailAddress(ErrorMessage ="please enter a valid email address")]
        public string Email { get; init; }

        [Required(ErrorMessage ="Please enter your offer")]
        public string Message { get; init; }
        [Required]
        public string ClientId { get; init; }
        [Required]
        public string FreelancerId { get; init; }
        public bool? Accepted { get; set; }
        public DateTime? offerDate { get; set; }
    }
}
