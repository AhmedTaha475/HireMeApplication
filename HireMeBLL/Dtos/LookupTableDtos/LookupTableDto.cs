using HireMeBLL.Dtos.LookupValuesDtos;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class LookupTableDto
    {
        [Required] 
        public int LookupId { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string LookupName { get; set; }

        public List<LookupValueDTO> lookupValuesdto { get; set; } = new List<LookupValueDTO>();

        
    }
}
