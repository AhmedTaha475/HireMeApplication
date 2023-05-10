using HireMeDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class Client:SystemUser
    {
        [Column(TypeName = "money")]
        public decimal TotalMoneySpent { get; set; } = 0;
        public virtual HashSet<ProjectComment> ProjectComments { get; set; } = new HashSet<ProjectComment>();
        public virtual HashSet<Project> Projects { get; set; } = new HashSet<Project>();
        public virtual HashSet<ProjectPost> ProjectPosts { get; set; } = new HashSet<ProjectPost>();
        public virtual HashSet<ProjectReview> ProjectReviews { get; set; } = new HashSet<ProjectReview>();

        
    }

}
