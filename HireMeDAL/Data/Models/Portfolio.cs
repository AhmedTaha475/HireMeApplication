using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HireMeDAL
{
    public class Portfolio
    {
        [Key]
        public int PortId { get; set; }

        public string FreelancerId { get; set; } = string.Empty; ///

        [ForeignKey("FreelancerId")]
        //[BindNever]
        public virtual Freelancer? Freelancer { get; set; }

        public virtual HashSet<Project> Projects { get; set; } = new HashSet<Project>();

    }
}
