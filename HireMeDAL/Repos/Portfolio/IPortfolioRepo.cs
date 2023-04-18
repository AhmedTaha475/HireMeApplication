using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeDAL.Data.Models; 

namespace HireMeDAL
{
    public interface IPortfolioRepo
    {
        public IEnumerable<Portfolio> GetAll();
        public Portfolio GetById(int id);
        public bool AddPortfolio (Portfolio portfolio);
        public bool DeletePortfolio(int id);
        public void saveChanges(); 

    }
}
