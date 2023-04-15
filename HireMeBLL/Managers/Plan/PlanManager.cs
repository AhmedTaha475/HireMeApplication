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

        public void AddPlan(PlanReadDto plan)
        {
            var planDto = new Plan() {id=plan.id, Name= plan.Name, Price= plan.Price, Description= plan.Description, Bids= plan.Bids };
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
                p => new PlanReadDto() { id= p.id,Name=p.Name,Description= p.Description,Price= p.Price,Bids= p.Bids});
        }

        public PlanReadDto GetById(int id)
        {
            var planFromDb = _planRepo.GetById(id);
            return new PlanReadDto() { id = planFromDb.id, Name = planFromDb.Name, Price = planFromDb.Price, Description = planFromDb.Description, Bids = planFromDb.Bids };
        }
        public void UpdatePlan(PlanReadDto plan)
        {
            var planDto = new Plan() { id = plan.id, Name = plan.Name, Price = plan.Price, Description = plan.Description, Bids = plan.Bids };
            _planRepo.UpdatePlan(planDto);

        }
    }
}
