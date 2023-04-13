using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class ProjectReview
    {
        [Key]
        public int PR_Id { get; set; }
        [MaxLength(300)]
        public string ClientReview { get; set; }
        [MaxLength(300)]
        public string FreelancerReview { get; set; }

        public int ClientStars { get; set; }

        public int FreelancerStars { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project? Project { get; set; }
    }
}
