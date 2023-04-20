using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.ProjectPost
{
    public record ProjectPostDto
    {

        public int Id { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public decimal AveragePrice { get; set; }
        
        public int CategoryId { get; set; }
        
       
    }
}
