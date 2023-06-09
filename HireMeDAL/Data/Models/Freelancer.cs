﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{

    public class Freelancer:SystemUser
    {
        //Might Be Adjusted
        
        public int Rank { get; set; }
        
        public string ?JobTitle { get; set; }

        public int Bids { get; set; } = 0;

        public string ? Description { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalMoneyEarned { get; set; } = 0;

        public byte[] ?CV { get; set; }
        [Column(TypeName = "money")]
        public decimal AverageRate { get; set; }

        public virtual Portfolio? Portfolio { get; set; }

        public virtual HashSet<ProjectPostApplicant> ProjectPostApplicants { get; set; } = new HashSet<ProjectPostApplicant>();
        public virtual HashSet<ProjectReview> ProjectReviews { get; set; } = new HashSet<ProjectReview>();

        public virtual HashSet<Offer> Offers { get; set; } = new HashSet<Offer>();


    }
}
