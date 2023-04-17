using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record CreateProjectCommentDto
    {
        public string Comment { get; init; } = string.Empty;
        public int ProjectId { get; init; }
        public string ClientId { get; init;} 
    }
}
