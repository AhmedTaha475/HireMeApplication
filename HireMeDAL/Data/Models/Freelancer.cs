using System;
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

        public int Bids { get; set; }

        public string ? Description { get; set; }

        public decimal TotalMoneyEarned { get; set; }

        public byte[] ?CV { get; set; }

        public decimal AverageRate { get; set; }

        public int PortfolioId { get; set; }

        [ForeignKey("PortfolioId")]
        public virtual Portfolio? Portfolio { get; set; }

        public virtual HashSet<ProjectPostApplicant> ProjectPostApplicants { get; set; } = new HashSet<ProjectPostApplicant>();
        public virtual HashSet<ProjectReview> ProjectReviews { get; set; } = new HashSet<ProjectReview>();



    }
}
