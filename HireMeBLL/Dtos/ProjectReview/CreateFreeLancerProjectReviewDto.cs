using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.ProjectReview
{
    public record CreateFreeLancerProjectReviewDto
    {
        public string FreeLancer_Id { get; init; }
        [Required]
        public string Freelncer_Review { get; init; } = string.Empty;
        [Required]
        public int Freelancer_Stars { get; init; }
        [Required]
        public int Project_Id { get; init; }
    }
}
