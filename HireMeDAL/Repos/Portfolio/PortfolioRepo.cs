//using HireMeDAL.Repos.Portfolio;
using Microsoft.AspNetCore.Authorization.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeDAL.Repos;
using FluentNHibernate.Conventions.Inspections;

namespace HireMeDAL
{
    public class PortfolioRepo : IPortfolioRepo
    {
        private readonly HireMeContext _context;
        public PortfolioRepo(HireMeContext context) 
        { 
            _context= context;
        }

        public bool AddPortfolio(Portfolio portfolio)
        {
            if (portfolio != null)
            {
                _context.portfolios.Add(portfolio);
                _context.SaveChanges();
                return true;
            }
            else return false; 
        }

        public bool DeletePortfolio(int id)
        {
            var port = _context.portfolios.Find(id);
            if (port != null)
            {
                _context.portfolios.Remove(port);
                _context.SaveChanges();
                return true;
            }
            else return false;  
        }

        public IEnumerable<Portfolio> GetAll()
        {
            if(_context.portfolios != null)
            {
                return _context.portfolios.ToList();
            }
          else  return null; 
        }

        public Portfolio GetById(int id)
        {
            return _context.portfolios.Find(id) ?? null;
        }

        public void saveChanges()
        {
          _context.SaveChanges(); 
        }
    }
}
