using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos
{
    public record PlanReadDto(int id, string Name , string Description , decimal Price, int Bids);

}
