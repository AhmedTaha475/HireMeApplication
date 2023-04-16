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
        [StringLength(15, MinimumLength = 2,ErrorMessage = "your Lookup Table value Length must be in range 2 - 15 chars only ")]
        public string ValueName { get; set; }
        [Required]
        public int LookupId { get; set; }
    }
}
