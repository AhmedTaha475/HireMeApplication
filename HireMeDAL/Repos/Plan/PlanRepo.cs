using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class PlanRepo : IPlanRepo
    {
        private readonly HireMeContext _context; 
        public PlanRepo(HireMeContext context) 
        { 
        _context= context;
                }
        public void AddPlan(Plan plan)
        {
            if (plan != null)
            {
                _context.plans.Add(plan);
                _context.SaveChanges();
            }
            else return; 
        }

        public void DeletePlan(int id)
        {
            var plan = _context.plans.Find(id);
            if (plan != null)
            {
                _context.plans.Remove(plan);
                _context.SaveChanges();
            }
            else return; 
        }

        public IEnumerable<Plan> GetAll()
        {
            if (_context.plans != null)
            {
                return _context.plans.ToList(); 

            }
            else return Enumerable.Empty<Plan>(); ////
        }

        public Plan GetById(int id)
        {
            return _context.plans.Find(id) ?? new Plan(); 
        }

      
        public void UpdatePlan(Plan plan)
        {
            var myPlan = _context.plans.Find(plan.id);
            if (myPlan != null)
            {
                myPlan.Description = plan.Description;
                myPlan.Price = plan.Price;
                myPlan.Name = plan.Name;
                myPlan.Bids = plan.Bids;
                _context.SaveChanges();
            }
            else return; 
        }
        public void saveChanges()
        {
            _context.SaveChanges();
        }

    }
}
