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
            if(lookupvaluesDb !=null)
            {
                var lookvaluesdtolist = new List<LookupValueDTO>();
                foreach (LookupValue lookupvalue in lookupvaluesDb)
                {
                    lookvaluesdtolist.Add(new LookupValueDTO() { LookupId = lookupvalue.LookupId, ValueName = lookupvalue.ValueName, ValueId = lookupvalue.ValueId });

                }
                return lookvaluesdtolist;
            }return null;
     
        }

        // ===== this function to get all lookup values for specific lookup table (Name) ===== // 
        public IEnumerable<LookupValueDTO> GetLookupValuesByLookupName(string name)
        {
            var lookupvaluesDb = lookupValuesRepo.GetLookupValuesByLookupName(name);
            if(lookupvaluesDb !=null)
            {
                var lookvaluesdtolist = new List<LookupValueDTO>();
                foreach (LookupValue lookupvalue in lookupvaluesDb)
                {
                    lookvaluesdtolist.Add(new LookupValueDTO() { LookupId = lookupvalue.LookupId, ValueName = lookupvalue.ValueName, ValueId = lookupvalue.ValueId });

                }
                return lookvaluesdtolist;
            }return null;
            
        }


        public List<LookupValueDTO> GetAllLookupValues()
        {
            var list = lookupValuesRepo.GetAllLookupValues();

              

            if (list!= null)
            {
                return list.Select(v => new LookupValueDTO() { ValueId = v.ValueId, ValueName = v.ValueName, LookupId = v.LookupId }).ToList();
            }
            else return null;
        }

        public LookupValueDTO GetLookupValueById(int id)
        {
            var value=lookupValuesRepo.GetLookupValueById(id);
            if(value != null)
                return new LookupValueDTO() { LookupId = value.LookupId, ValueName = value.ValueName,ValueId=value.ValueId };
            return null;
        }


        #endregion

        #region All Create Cruds in Lookup Value Manager Class

        // ==== thiis function to create new lookup value ===== // 
        public bool CreateLookupValue(CreateLookupValueDto lookvaluedto)
        {
            LookupValue lookuptodb = new LookupValue() { ValueName = lookvaluedto.ValueName,LookupId=lookvaluedto.LookupId };

           if( lookupValuesRepo.CreateLookupValue(lookuptodb))
            {
                return true;

            }return false;
        }

        #endregion

        #region All Update Cruds in Lookup Value Manager Class
        public bool UpdateLookupValueById(string valuename, int id)
        {
            var lookupvaluefromdb = lookupValuesRepo.GetLookupValueById(id);
            if (lookupvaluefromdb != null ) 
            {
                lookupvaluefromdb.ValueName = valuename;
                return lookupValuesRepo.UpdateLookupValueById(lookupvaluefromdb, id); ;
            }
            return false;
        }

        #endregion

        #region All Delete Cruds in Lookup Value Manager Class

        // ===== this function to delete lookup value by its Id =====  //
        public bool DeleteLookupValueById(int id)
        {
            return lookupValuesRepo.DeleteLookupValueById(id);
        }
        #endregion

    }
}
