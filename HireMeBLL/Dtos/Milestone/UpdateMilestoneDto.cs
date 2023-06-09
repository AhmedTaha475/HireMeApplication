﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record UpdateMilestoneDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }

        public bool? released { get; set; }
    }
}
