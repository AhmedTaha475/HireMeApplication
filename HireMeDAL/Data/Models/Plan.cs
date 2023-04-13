using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class Plan
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty; 

        public string Description { get; set; } = string.Empty;
        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }

        public int Bids { get; set; }

        public virtual HashSet<SystemUser>? SystemUsers { get; set; } = new HashSet<SystemUser>();
    }
}
