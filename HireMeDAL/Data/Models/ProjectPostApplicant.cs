﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class ProjectPostApplicant
    {
       

        public string Proposal { get; set; }
        [Column(TypeName = "money")]
        public decimal BiddingPrice { get; set; }

        public int PP_ID { get; set; }

        public bool? Approved { get; set; }

        [ForeignKey("PP_ID")]
        public virtual ProjectPost? ProjectPost { get; set; }

        
        public string FreelancerId { get; set; }

        [ForeignKey("FreelancerId")]
        public virtual Freelancer? Freelancer { get; set; }
    }
}
