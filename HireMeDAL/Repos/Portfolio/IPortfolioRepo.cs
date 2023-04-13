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
        IEnumerable<Portfolio> GetAll();
        int saveChanges(); 
    }
}
