using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.ProjectReview
{
    public record CreateClientProjectReviewDto
    {
        public string Client_Id { get; init; }
        public int P_Id { get; init; }
        [Required]
        public string Client_Review { get; init; } = string.Empty;
        [Required]
        public int Client_Stars { get; init; }

    }
}
