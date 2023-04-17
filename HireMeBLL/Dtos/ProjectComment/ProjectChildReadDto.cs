using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.ProjectComment
{
    public record ProjectChildReadDto
    {
        public int P_Id { get; init; }
        public string Title { get; init;}
    }
}
