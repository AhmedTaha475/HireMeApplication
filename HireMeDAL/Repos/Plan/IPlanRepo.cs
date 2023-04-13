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
        public void DeletePlan(int id); 
        public void UpdatePlan(Plan plan);
        public void AddPlan(Plan plan);
        public void saveChanges(); 
    }
}
