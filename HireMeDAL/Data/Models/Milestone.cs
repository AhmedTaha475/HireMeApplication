using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class Milestone
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int ProjectPostId { get; set; }
        [ForeignKey("ProjectPostId")]
        public virtual ProjectPost? ProjectPost { get; set; }
    }
}
