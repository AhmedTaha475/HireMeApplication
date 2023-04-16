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
        public LookupTableDto GetLookupTableByName(string name);

        #endregion

        #region Create Crud( Manager Interface )
        public void CreateNewLookupTable(LookupTableDto lookupTableDto);


        #endregion

        #region Update Crud( Manager Interface )
        public void UpdateLookupTableById(LookupTableDto lookupTableDto, int id);
        public void UpdateLookupTableByName(LookupTableDto lookupTableDto, string name);

        #endregion

        #region Delete Crud( Manager Interface )
        public void  DeleteLookupTableById(int id);
        public void  DeleteLookupTableByName(string name);

        #endregion
    }
}
