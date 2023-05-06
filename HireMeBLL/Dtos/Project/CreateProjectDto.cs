using HireMeDAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.Project
{
    public record CreateProjectDto
    {
        [Required]
        public string Title { get; init; } = string.Empty;
        [Required]
        public string Description { get; init; }= string.Empty;
        [Required]
        public decimal MoneyEarned { get; init; }
        [Required]
        public DateTime Date { get; init; }
        [Required]
        public bool SystemProject { get; init; }
        public string? ClientId { get; init; }
        [Required]
        public int portfolioId { get; set; }
        public List<IFormFile>? projectImgs { get; init; }   

    }
}
