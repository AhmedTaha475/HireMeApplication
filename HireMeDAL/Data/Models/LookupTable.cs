using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class LookupTable
    {
        [Key]
        public int LookupId { get; set; }
        [Required]
        [StringLength(15,MinimumLength = 3)]
        public string LookupName { get; set; }

        public virtual HashSet<LookupValue> LookupValues { get; set; }= new HashSet<LookupValue>();
    }
}
