using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class LookupValue
    {

        public int ValueId { get; set; }

        public string ValueName { get; set; }

        public int LookupId { get; set; }
        [ForeignKey("LookupId")]
        public virtual  LookupTable? LookupTable { get; set; }


        public virtual HashSet<Freelancer> Freelancers { get; set; } = new HashSet<Freelancer>();
        public virtual HashSet<SystemUser> SystemUsers { get; set; } = new HashSet<SystemUser>();
        public virtual HashSet<ProjectPost> ProjectPosts { get; set; } = new HashSet<ProjectPost>();


    }
}
