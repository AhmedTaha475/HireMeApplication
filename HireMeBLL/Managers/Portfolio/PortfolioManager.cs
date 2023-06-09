﻿using HireMeDAL;
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

        public bool AddPortfolio(string freelancerId)
        {
            var portfolioDto = new Portfolio() {  FreelancerId = freelancerId };
            return _portfolioRepo.AddPortfolio(portfolioDto);
        }


        public bool DeleteById(int id)
        {
            return _portfolioRepo.DeletePortfolio(id);
        }

        public IEnumerable<PortfolioReadDto> GetAll()
        {
            var portfolioFromDb = _portfolioRepo.GetAll();
            if(portfolioFromDb != null)
                return portfolioFromDb.Select(
                    p => new PortfolioReadDto() { PortId= p.PortId, FreelancerId= p.FreelancerId }).ToList();
            return null;
        }

        public PortfolioReadDto GetById(int id)
        {
            var portfolioFromDb = _portfolioRepo.GetById(id);
            if(portfolioFromDb != null)
                return new PortfolioReadDto() { PortId=portfolioFromDb.PortId, FreelancerId= portfolioFromDb.FreelancerId };
            return null;
        }
    }
}
