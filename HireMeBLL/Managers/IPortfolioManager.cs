using HireMeBLL.Dtos;
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
        public void DeleteById(int id);
        public void AddPortfolio(Portfolio portfolio); 

    }
}
