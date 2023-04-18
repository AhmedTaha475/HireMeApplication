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
        public bool AddPlan(Plan plan)
        {
            if (plan != null)
            {
                _context.plans.Add(plan);
                _context.SaveChanges();
                return true;
            }
            else return false; 
        }

        public bool DeletePlan(int id)
        {
            var plan = _context.plans.Find(id);
            if (plan != null)
            {
                _context.plans.Remove(plan);
                _context.SaveChanges();
                return true;
            }
            else return false; 
        }

        public IEnumerable<Plan> GetAll()
        {
            if (_context.plans != null)
            {
                return _context.plans.ToList(); 

            }
            else return null; ////
        }

        public Plan GetById(int id)
        {
            return _context.plans.Find(id) ?? null; 
        }

      
        public bool UpdatePlan(Plan plan)
        {
            var myPlan = _context.plans.Find(plan.id);
            if (myPlan != null)
            {
                myPlan.Description = plan.Description;
                myPlan.Price = plan.Price;
                myPlan.Name = plan.Name;
                myPlan.Bids = plan.Bids;
                _context.SaveChanges();
                return true;
            }
            else return false; 
        }
        public void saveChanges()
        {
            _context.SaveChanges();
        }

    }
}
