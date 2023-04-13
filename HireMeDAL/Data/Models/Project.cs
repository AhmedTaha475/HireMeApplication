using FluentNHibernate.Conventions.Inspections;
using HireMeDAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [MaxLength(300)]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"), Display(Name = "Date")]
        public DateTime ProjectDate { get; set; }
        [MaxLength(20,ErrorMessage ="Project title must be less than 20 charachters"),Display(Name = "Title")]
        public string ProjectTitle { get; set; }
        [Display(Name = "System Project ?")]
        public bool SystemProject { get; set; }
        [Display(Name = "Profit"), Column(TypeName = "money")]
        public decimal MoneyEarned { get; set; }
        public int PortfolioId { get; set; }
        [ForeignKey("PortfolioId")]
        public virtual Portfolio? Portfolio { get; set; }
        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client? Client { get; set; }
        public int PR_Id { get; set; }
        [ForeignKey("PR_Id")]
        public virtual ProjectReview? ProjectReview { get; set; }
        public virtual HashSet<ProjectImage> ProjectImages { get; set; } = new HashSet<ProjectImage>();
        public virtual  HashSet<ProjectComment> ProjectComments { get; set; }= new HashSet<ProjectComment>();


    }
}
