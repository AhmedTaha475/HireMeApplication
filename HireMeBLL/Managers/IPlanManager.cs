using HireMeBLL.Dtos;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Managers
{
    internal interface IPlanManager
    {
        public IEnumerable<PlanReadDto> GetAll();
        public PlanReadDto GetById(int id);
        public void DeleteById(int id);
        public void AddPlan(PlanReadDto plan);
        public void UpdatePlan(PlanReadDto plan); 
    }
}
