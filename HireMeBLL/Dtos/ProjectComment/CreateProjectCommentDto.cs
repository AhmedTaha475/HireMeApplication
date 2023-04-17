using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.ProjectComment
{
    public record CreateProjectCommentDto
    {
        public string Comment { get; init; } = string.Empty;
        public string ClientId { get; init;} 
    }
}
