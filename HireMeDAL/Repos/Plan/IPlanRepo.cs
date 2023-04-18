using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface IPlanRepo
    {
        public IEnumerable<Plan> GetAll(); 
        public Plan GetById(int id);
        public bool DeletePlan(int id); 
        public bool UpdatePlan(Plan plan);
        public bool AddPlan(Plan plan);
        public void saveChanges(); 
    }
}
