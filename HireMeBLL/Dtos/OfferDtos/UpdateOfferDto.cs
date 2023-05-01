using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record UpdateOfferDto
    {
        [Required]
        public int id { get; init; }

        public string? Fullname { get; init; }
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string? Email { get; init; }

        public string? Message { get; init; }

        public bool? Accepted { get; set; }

        public DateTime? OfferDate { get; set; }


    }
}
