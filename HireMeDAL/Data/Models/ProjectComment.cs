using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Data.Models
{
    public class ProjectComment
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(200, ErrorMessage = "Comment length must be less than 200"), Required] 
        public string Comment { get; set; } = string.Empty;

        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public string ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client? Client { get; set; }

    }
}
