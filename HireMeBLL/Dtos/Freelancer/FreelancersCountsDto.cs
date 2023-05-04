using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.Freelancer
{
    public record FreelancersCountsDto
    {
        public int[] counts { get; set; }
    }
}
