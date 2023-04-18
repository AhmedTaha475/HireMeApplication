using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface ILookupTableManager
    {

        #region Get Crud( Manager Interface )
        public IEnumerable<LookupTableDto> GetAllLookupTables();
        public LookupTableDto GetLookupTableById(int id);
        //public LookupTableDto GetLookupTableByName(string name);

        #endregion

        #region Create Crud( Manager Interface )
        public bool CreateNewLookupTable(string lookupname);


        #endregion

        #region Update Crud( Manager Interface )
        public bool UpdateLookupTableById(string name, int id);
        public bool UpdateLookupTableByName(LookupTableDto lookupTableDto, string name);

        #endregion

        #region Delete Crud( Manager Interface )
        public bool  DeleteLookupTableById(int id);
        public bool  DeleteLookupTableByName(string name);

        #endregion
    }
}
