using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record PojectReviewReadDto
    {
        public int PR_Id { get; init; }
        public string? ClientReview { get; init; } = string.Empty;
        public string? FreelancerReview { get; init; } = string.Empty;
        public int? ClientStars { get; init; }
        public int? FreelancerStars { get; init; }
        public UserChildReadDto Client { get; init; }
        public UserChildReadDto Freelancer { get; init; }
    }
}
