using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.Portfolio
{
    public record PortfolioReadDto
    {
        [Required]
        public int PortId { get; init; }
        [Required]
        public string FreelancerId { get; init; } = string.Empty;
    }

}
