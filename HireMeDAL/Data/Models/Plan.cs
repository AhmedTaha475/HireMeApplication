using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class Plan
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Bids { get; set; }

        public virtual HashSet<SystemUser>? SystemUsers { get; set; } = new HashSet<SystemUser>();
    }
}
