using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record UpdateFreelancerDto
    {
        public string Id { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Please enter first name between 3 and 20 character")]
        public string? FirstName { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Please enter last name between 3 and 20 character")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "User name can't be empty")]
        public string Username { get; set; }
        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        
        [Range(15, 65, ErrorMessage = "Client age should be between 15,65")]
        public int Age { get; set; }
        [RegularExpression(@"^([1-9]{1})([0-9]{2})([0-9]{2})([0-9]{2})([0-9]{2})[0-9]{3}([0-9]{1})[0-9]{1}$",
            ErrorMessage = "Please enter valid egyption NationalId")]
        public string? SSN { get; set; }

        public decimal? Balance { get; set; }

        public int? PaymentMethodId { get; set; }

        public int? PlanId { get; set; }
        public int? CategoryId { get; set; }
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string email { get; set; }

        [Range(0, 10, ErrorMessage = "Please enter a valid rank")]
        public int Rank { get; set; }

        public string? JobTitle { get; set; }
        [Range(0, 100, ErrorMessage = "Invalid amount of Bids")]
        public int Bids { get; set; }

        public string? Description { get; set; }

        public decimal TotalMoneyEarned { get; set; }

        

        public decimal AverageRate { get; set; }

        public int PortfolioId { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? CV { get; set; }
    }
}
