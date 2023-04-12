using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        public string Description { get; set; }

        public DateTime ProjectDate { get; set; }

        public string ProjectTitle { get; set; }

        public bool SystemProject { get; set; }

        public decimal MoneyEarned { get; set; }

        public string Comment { get; set; }

        public int PortfolioId { get; set; }

        [ForeignKey("PortfolioId")]
        public virtual Portfolio? Portfolio { get; set; }

        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client? Client { get; set; }

        public virtual HashSet<ProjectImage> ProjectImages { get; set; } = new HashSet<ProjectImage>();
        public virtual HashSet<ProjectReview> ProjectReviews { get; set; } = new HashSet<ProjectReview>();



    }
}
