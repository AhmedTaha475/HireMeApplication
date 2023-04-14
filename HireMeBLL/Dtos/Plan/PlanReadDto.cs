using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record PlanReadDto{

    [Required]
    public int id { get; init; }
    [Required]
    public string Name { get; init; } = string.Empty;
        [Required]
        public string Description { get; init; } = string.Empty;
        [Required]
        public decimal Price { get; init; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Bids { get; init; }

    }

}
