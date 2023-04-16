using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.LookupValuesDtos
{
    public class LookupValueDTO
    {
        [Required]
        public int ValueId { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string ValueName { get; set; }
        [Required]
        public int LookupId { get; set; }
    }
}
