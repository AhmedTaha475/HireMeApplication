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
        [MaxLength(300), Required]
        public string ClientReview { get; set; }=string.Empty;
        [MaxLength(300), Required]
        public string FreelancerReview { get; set; }=string.Empty;
        [Required]
        public int ClientStars { get; set; }
        [Required]
        public int FreelancerStars { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project? Project { get; set; }
        public string FreeLancerId { get; set; }
        [ForeignKey("FreeLancerId")]
        public virtual Freelancer? Freelancer { get; set; }
    }
}
