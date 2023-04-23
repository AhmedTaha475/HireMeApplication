//using HireMeBLL.Dtos.Plan;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace HireMeBLL
{
    public class PlanManager : IPlanManager
    {

        private readonly IPlanRepo _planRepo;

        public PlanManager(IPlanRepo planRepo)

        {
            _planRepo = planRepo;
        }

        public bool AddPlan(CreatePlanDto plan)
        {
            var planDto = new Plan() { Name= plan.Name, Price= plan.Price, Description= plan.Description, Bids= plan.Bids };
            return _planRepo.AddPlan(planDto);
        }



        public bool DeleteById(int id)
        {
            return _planRepo.DeletePlan(id);
        }

        public IEnumerable<PlanReadDto> GetAll()
        {
            var planFromDb = _planRepo.GetAll();
            if (planFromDb != null)
                return planFromDb.Select(
                   p => new PlanReadDto() { id = p.id, Name = p.Name, Description = p.Description, Price = p.Price, Bids = p.Bids }).ToList();
            else
                return null;
        }

        public PlanReadDto GetById(int id)
        {
            var planFromDb = _planRepo.GetById(id);
            if (planFromDb != null)
                return new PlanReadDto() { id = planFromDb.id, Name = planFromDb.Name, Price = planFromDb.Price, Description = planFromDb.Description, Bids = planFromDb.Bids };
            return null;
        }
        public bool UpdatePlan(PlanReadDto plan)
        {
            var planDto = new Plan() { id = plan.id, Name = plan.Name, Price = plan.Price, Description = plan.Description, Bids = plan.Bids };
            return _planRepo.UpdatePlan(planDto);

        }
    }
}
