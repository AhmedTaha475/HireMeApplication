using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface ILookupTableRepo
    {
        #region Get Cruds In Lookup Table Repo (Interface)
        public IEnumerable<LookupTable> GetAllLookups();
        public LookupTable GetLookupById(int id); 
        public LookupTable GetLookupByName(string name);

        #endregion

        #region Update Cruds In Lookup Table Repo (Interface) 
        public void UpdateLookupById( LookupTable lookup , int id);
        public void UpdateLookupByName( LookupTable lookup , string name);

        #endregion

        #region Create Cruds In Lookup Table Repo (Interface)
        public void CreateNewLookup(LookupTable lookup);

        #endregion

        #region Delete Cruds In Lookup Table Repo (Interface)
        public void DeleteLookupById(int id);
        public void DeleteLookupByName(string name);

        #endregion

        #region Helper Methods to save in context (Interface)
        public void saveChanges();

        #endregion

    }
}
