using HireMeBLL.Dtos.LookupValuesDtos;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class LookupValueManager: ILookupValueManager
    {
        #region Constructor && All Injecton Requires in Lookup Value manager Class 
        private readonly ILookupValuesRepo lookupValuesRepo;

        public LookupValueManager( ILookupValuesRepo lookupValuesRepo)
        {
            this.lookupValuesRepo = lookupValuesRepo;
        }

        #endregion

        #region All Get Cruds in Lookup Value Manager Class

        // ===== this function to get all lookup values for specific lookup table (Id) ===== // 
        public IEnumerable<LookupValueDTO> GetLookupValuesByLookupId(int id)
        {
            var lookupvaluesDb = lookupValuesRepo.GetLookupValuesByLookupId(id);

            var lookvaluesdtolist = new List<LookupValueDTO>();
            foreach (LookupValue lookupvalue in lookupvaluesDb)
            {
                lookvaluesdtolist.Add(new LookupValueDTO() { LookupId = lookupvalue.LookupId, ValueName = lookupvalue.ValueName, ValueId = lookupvalue.ValueId });

            }
            return lookvaluesdtolist;
        }

        // ===== this function to get all lookup values for specific lookup table (Name) ===== // 
        public IEnumerable<LookupValueDTO> GetLookupValuesByLookupName(string name)
        {
            var lookupvaluesDb = lookupValuesRepo.GetLookupValuesByLookupName(name);
            var lookvaluesdtolist = new List<LookupValueDTO>();
            foreach (LookupValue lookupvalue in lookupvaluesDb)
            {
                lookvaluesdtolist.Add(new LookupValueDTO() { LookupId = lookupvalue.LookupId, ValueName = lookupvalue.ValueName, ValueId = lookupvalue.ValueId });

            }
            return lookvaluesdtolist;
        }

        #endregion

        #region All Create Cruds in Lookup Value Manager Class

        // ==== thiis function to create new lookup value ===== // 
        public void CreateLookupValue(LookupValueDTO lookvaluedto)
        {
            LookupValue lookuptodb = new LookupValue() { ValueName = lookvaluedto.ValueName };

            lookupValuesRepo.CreateLookupValue(lookuptodb);
        }

        #endregion

        #region All Update Cruds in Lookup Value Manager Class
        public void UpdateLookupValueById(LookupValueDTO lookupValue, int id)
        {
            var lookupvaluefromdb = lookupValuesRepo.GetLookupValueById(id);
            if (lookupvaluefromdb != null && lookupvaluefromdb.LookupId == id) ;
            {
                lookupvaluefromdb.ValueName = lookupValue.ValueName;
                lookupValuesRepo.UpdateLookupValueById(lookupvaluefromdb, id);
            }
        }

        #endregion

        #region All Delete Cruds in Lookup Value Manager Class

        // ===== this function to delete lookup value by its Id =====  //
        public void DeleteLookupValueById(int id)
        {
            lookupValuesRepo.DeleteLookupValueById(id);
        }

       

        #endregion

    }
}
