using HireMeBLL.Dtos.Portfolio;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IPortfolioManager
    {
        public IEnumerable<PortfolioReadDto> GetAll();
        public PortfolioReadDto GetById(int id);
        public bool DeleteById(int id);
        public bool AddPortfolio(string freelancerId);

    }
}
