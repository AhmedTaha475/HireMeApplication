using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.Project
{
    public record UpdateProjectByIdDto
    {
        [Required]
        public int ProjectID { get; set; }
        
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime ProjectDate { get; set; }
        [MaxLength(20, ErrorMessage = "Project title must be less than 20 charachters"), Required]
        public string ProjectTitle { get; set; } = string.Empty;
        [Required]
        public bool SystemProject { get; set; }
        [Column(TypeName = "money"), Required]
        public decimal MoneyEarned { get; set; }
    }
}
