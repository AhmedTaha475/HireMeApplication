using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeBLL;

namespace HireMeBLL.Dtos
{
    public record ProjectDetailsReadDto
    {
        public int P_Id { get; init; }
        public string Description { get; init; }
        public string Title { get; init; }
        public DateTime Date { get; init; }
        public bool SystemProject { get; init; }
        public decimal MoneyEarned { get; init; }


    }
}
