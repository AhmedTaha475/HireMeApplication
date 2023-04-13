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

        public void AddPortfolio(Portfolio portfolio)
        {
            if (portfolio != null)
            {
                _context.portfolios.Add(portfolio);
                _context.SaveChanges();

            }
            else return; 
        }

        public void DeletePortfolio(int id)
        {
            var port = _context.portfolios.Find(id);
            if (port != null)
            {
                _context.portfolios.Remove(port);
            }
            else return; 
        }

        public IEnumerable<Portfolio> GetAll()
        {
            if(_context.portfolios != null)
            {
                return _context.portfolios.ToList();
            }
          else  return Enumerable.Empty<Portfolio>(); 
        }

        public Portfolio GetById(int id)
        {
                return _context.portfolios.Find(id)??new Portfolio(); //////
        }

        public void saveChanges()
        {
          _context.SaveChanges(); 
        }
    }
}
