using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Data.Models
{
    public class ProjectComment
    {

        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }

        public int ProjectId { get; set; }

        public virtual Project? Project { get; set; }

    }
}
