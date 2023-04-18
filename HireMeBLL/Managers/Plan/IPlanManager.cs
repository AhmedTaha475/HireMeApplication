
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IPlanManager
    {
        public IEnumerable<PlanReadDto> GetAll();
        public PlanReadDto GetById(int id);
        public bool DeleteById(int id);
        public bool AddPlan(CreatePlanDto plan);
        public bool UpdatePlan(PlanReadDto plan);
    }
}
