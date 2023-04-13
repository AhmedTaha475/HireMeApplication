using HireMeDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record ProjectPostWithApplicantsDetailsDto
    {
        [Required]
        public string PostTitle { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal AveragePrice { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public List<ProjectPostApplicantDetailsDto> ProjectPostApplicants { get; set; }
    }
}
