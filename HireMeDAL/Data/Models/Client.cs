using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class Client:SystemUser
    {
        public decimal TotalMoneySpent { get; set; }


        public virtual HashSet<Project> Projects { get; set; } = new HashSet<Project>();
        public virtual HashSet<ProjectPost> ProjectPosts { get; set; } = new HashSet<ProjectPost>();

    }

}
