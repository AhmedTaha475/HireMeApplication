using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface ILookupValuesRepo
    {

        #region Get Cruds in Lookup Values Repo(Interface)
       

        
        public IEnumerable<LookupValue> GetLookupValuesByLookupId( int id );
        public IEnumerable<LookupValue> GetLookupValuesByLookupName( string name );

        public List<LookupValue> GetAllLookupValues();

        public LookupValue GetLookupValueById(int id);

        #endregion

        #region Create Cruds in Lookup Values Rep (Interface)
        public bool CreateLookupValue(LookupValue lookvalue);


        #endregion

        #region Update Cruds in Lookup Values Repo (Interface)
        public bool UpdateLookupValueById(LookupValue lookvalue, int id );

        #endregion

        #region Delete Cruds in Lookup Values Repo (Interface)
        public bool DeleteLookupValueById(int id);

        #endregion

        #region Helper Methods to save in context (Interface)
        public void saveChanges();

        #endregion

    }
}
