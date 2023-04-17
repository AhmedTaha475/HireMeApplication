using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeDAL.Data.Models;
using HireMeBLL.Dtos.Portfolio;

namespace HireMeBLL
{

    public class PortfolioManager : IPortfolioManager
    {
        private readonly IPortfolioRepo _portfolioRepo;

        public PortfolioManager(IPortfolioRepo portfolioRepo)

        {
            _portfolioRepo = portfolioRepo;
        }

        public void AddPortfolio(PortfolioReadDto portfolio)
        {
            var portfolioDto = new Portfolio() { PortId = portfolio.PortId, FreelancerId = portfolio.FreelancerId };
            _portfolioRepo.AddPortfolio(portfolioDto);
        }


        public void DeleteById(int id)
        {
            _portfolioRepo.DeletePortfolio(id);
        }

        public IEnumerable<PortfolioReadDto> GetAll()
        {
            var portfolioFromDb = _portfolioRepo.GetAll();
            return portfolioFromDb.Select(
                p => new PortfolioReadDto() { PortId= p.PortId, FreelancerId= p.FreelancerId });
        }

        public PortfolioReadDto GetById(int id)
        {
            var portfolioFromDb = _portfolioRepo.GetById(id);
            return new PortfolioReadDto() { PortId=portfolioFromDb.PortId, FreelancerId= portfolioFromDb.FreelancerId };
        }
    }
}
