using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class ProjectPost
    {
        [Key]
        public int Pp_Id { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string PostTitle { get; set; } = string.Empty;

        [Required]
        public decimal AveragePrice { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual LookupValue? LookupValue { get; set; }

        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client? Client { get; set; }


        public virtual HashSet<Milestone> Milestones { get; set; } = new HashSet<Milestone>();
        public virtual HashSet<ProjectPostApplicant> ProjectPostApplicants { get; set; } = new HashSet<ProjectPostApplicant>();



    }
}
