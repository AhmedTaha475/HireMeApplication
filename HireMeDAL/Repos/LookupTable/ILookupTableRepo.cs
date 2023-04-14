using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface ILookupTableRepo
    {
       public IEnumerable<LookupTable> GetAllLookups();
        public LookupTable GetLookupById(int id); 
        public LookupTable GetLookupByName(string name);
        public void UpdateLookupById( LookupTable lookup , int id);
        public void UpdateLookupByName( LookupTable lookup , string name);
        public void CreateNewLookup(LookupTable lookup);
        public void DeleteLookupById(int id);
        public void DeleteLookupByName(string name);
        public void saveChanges();



    }
}
