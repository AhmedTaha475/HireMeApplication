using HireMeBLL.Dtos;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Managers
{
    public class PlanManager : IPlanManager
    {

        private readonly IPlanRepo _planRepo;

        public PlanManager(IPlanRepo planRepo)

        {
        _planRepo= planRepo;
        }

        public void AddPlan(PlanReadDto plan)
        {
            var planDto = new Plan(plan.id , plan.Name , plan.Price , plan.Description , plan.Bids);
           _planRepo.AddPlan(planDto);
        }

      

        public void DeleteById(int id)
        {
           _planRepo.DeletePlan(id);
        }

        public IEnumerable<PlanReadDto> GetAll()
        {
            var planFromDb = _planRepo.GetAll();
            return planFromDb.Select(
                p => new PlanReadDto(p.id , p.Name ,p.Description ,p.Price ,p.Bids));
        }

        public PlanReadDto GetById(int id)
        {
            var planFromDb = _planRepo.GetById(id);
            return new PlanReadDto(planFromDb.id , planFromDb.Name , planFromDb.Description, planFromDb.Price, planFromDb.Bids);
        }
        public void UpdatePlan(PlanReadDto plan)
        {
            var planDto = new Plan(plan.id, plan.Name, plan.Price, plan.Description, plan.Bids);
            _planRepo.UpdatePlan(planDto);
    
        }
    }
}
