﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record UpdateProjectPostDto
    {
        [Required]
        public string PostTitle { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public DateTime? ProjectPostDate { get; set; }
        [Required]
        public decimal AveragePrice { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public bool? Done { get; set; }

        public bool? approved { get; set; }
        public string? location { get; set; }
    }
}
