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
        public bool UpdateLookupById( string name , int id);
        public bool UpdateLookupByName( LookupTable lookup , string name);

        #endregion

        #region Create Cruds In Lookup Table Repo (Interface)
        public bool CreateNewLookup(LookupTable lookup);

        #endregion

        #region Delete Cruds In Lookup Table Repo (Interface)
        public bool DeleteLookupById(int id);
        public bool DeleteLookupByName(string name);

        #endregion

        #region Helper Methods to save in context (Interface)
        public void saveChanges();

        #endregion

    }
}
