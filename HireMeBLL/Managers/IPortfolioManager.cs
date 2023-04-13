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
        IEnumerable<PortfolioReadDto> GetAll();
        PortfolioReadDto GetById(int id); 
        void DeleteByI(int id);
        void AddPortfolio(Portfolio portfolio); 

    }
}
