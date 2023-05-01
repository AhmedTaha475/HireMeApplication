﻿using HireMeDAL;
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
        public int id { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        public DateTime? ProjectPostDate { get; set; }

        public decimal AveragePrice { get; set; }
        public int CategoryId { get; set; }
        public List<ProjectPostApplicantDetailsDto> ProjectPostApplicants { get; set; }
    }
}
