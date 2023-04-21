using HireMeBLL.Dtos.LookupValuesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface ILookupValueManager
    {
        #region Get Crud for Lookup Value Manager (Interface)

        public IEnumerable<LookupValueDTO> GetLookupValuesByLookupId(int id);
        public IEnumerable<LookupValueDTO> GetLookupValuesByLookupName(string name);

        List<LookupValueDTO> GetAllLookupValues();
        LookupValueDTO GetLookupValueById(int id);
        #endregion

        #region Create Crud for Lookup Value Manager (Interface)
        public bool  CreateLookupValue(CreateLookupValueDto lookvaluedto);

        #endregion

        #region Update Crud for Lookup Value Manager (Interface)
        public bool UpdateLookupValueById(string valuename, int id);

        #endregion

        #region Delte Crud for Lookup Value Manager (Interface)
        public bool DeleteLookupValueById(int id);

        #endregion


    }
}
