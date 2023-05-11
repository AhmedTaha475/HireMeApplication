using HireMeBLL.Dtos.ProjectComment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.ProjectReview
{
    public record UserPojectReviewReadDto
    {

        public int projectId { get; set; }
        public string? FreeLancerReview { get; init; } = string.Empty;
        public string? ClientReview { get; init; } = string.Empty;
        public int? FreeLancerStars { get; init; }
        public int? ClientStars { get; init; }
        [Required]
        public UserChildReadDto FreeLancer { get; init; }
        [Required]
        public UserChildReadDto Client { get; init; }
          
    }
}
