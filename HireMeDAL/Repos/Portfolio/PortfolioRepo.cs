using HireMeDAL.Repos.Portfolio;
using Microsoft.AspNetCore.Authorization.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeDAL.Repos; 
namespace HireMeDAL
{
    public class PortfolioRepo : IPortfolioRepo
    {
        private readonly HireMeContext _context;
        public PortfolioRepo(HireMeContext context) 
        { 
            _context= context;
        }

        public IEnumerable<Portfolio> GetAll()
        {
            return _context.portfolios; 
        }

        public int saveChanges()
        {
          return  _context.SaveChanges(); 
        }
    }
}
