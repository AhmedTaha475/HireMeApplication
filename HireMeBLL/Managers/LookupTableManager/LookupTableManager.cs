using HireMeBLL.Dtos.LookupValuesDtos;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class LookupTableManager : ILookupTableManager
    {
        #region Constructor & All Ingection Requires for Lookup Table Manager ( Class)
        private readonly ILookupTableRepo lookupTableRepo;
        private readonly ILookupValuesRepo lookupValuesRepo;

        public LookupTableManager( ILookupTableRepo lookupTableRepo , ILookupValuesRepo lookupValuesRepo)
        {
            this.lookupTableRepo = lookupTableRepo;
            this.lookupValuesRepo = lookupValuesRepo;
        }
        #endregion

        #region All Get Cruds for  LookupTables for Lookup Table Manager 

        // ======  Get ALL Lookup Tables  ===== //  
        public IEnumerable<LookupTableDto> GetAllLookupTables()
        {
            var lookuptablesDb = lookupTableRepo.GetAllLookups();
            var lookupdtolist = new List<LookupTableDto>();
            var lookvaluesdtolist = new List<LookupValueDTO>();
            foreach (LookupTable lookup in lookuptablesDb)
            {
                var lookupvaluesfromdto = lookupValuesRepo.GetLookupValuesByLookupId(lookup.LookupId).Select(l => new LookupValueDTO() { ValueId = l.ValueId, ValueName = l.ValueName, LookupId = l.LookupId });
                lookupdtolist.Add(new LookupTableDto() { LookupId = lookup.LookupId, LookupName = lookup.LookupName, lookupValuesdto = lookupvaluesfromdto.ToList() });

            }
            return lookupdtolist;
        }

        // ======  Get Lookup Table By Id  ===== // 
        public LookupTableDto GetLookupTableById(int id)
        {
            var lookupTablefromDb = lookupTableRepo.GetLookupById(id);
            var lookupvaluesfromdto = lookupValuesRepo.GetLookupValuesByLookupId(id).Select(l => new LookupValueDTO() { ValueId = l.ValueId, ValueName = l.ValueName, LookupId = l.LookupId });

            return new LookupTableDto() { LookupId = lookupTablefromDb.LookupId, LookupName = lookupTablefromDb.LookupName, lookupValuesdto = lookupvaluesfromdto.ToList() };
        }


        // ======  Get Lookup Table By Name ===== // 
        public LookupTableDto GetLookupTableByName(string name)
        {
            var lookuptablefromDb = lookupTableRepo.GetLookupByName(name);
            var lookuptablevaluesdtoname = lookupValuesRepo.GetLookupValuesByLookupName(name)
                .Select(l => new LookupValueDTO() { LookupId = l.LookupId, ValueId = l.ValueId, ValueName = l.ValueName });

            return new LookupTableDto() { LookupId = lookuptablefromDb.LookupId, LookupName = lookuptablefromDb.LookupName, lookupValuesdto = lookuptablevaluesdtoname.ToList() };


        }
        #endregion

        #region All Create Cruds for  LookupTables for Lookup Table Manager 
        public void CreateNewLookupTable(LookupTableDto lookupTableDto)
        {
            LookupTable lookuptoDb = new LookupTable() { 
            LookupName = lookupTableDto.LookupName
            };

            lookupTableRepo.CreateNewLookup(lookuptoDb);
        }
        #endregion
       
        #region All  Update Cruds for  LookupTables for Lookup Table Manager 

        // ===== Update LookupTable By Id ===== //
        public void UpdateLookupTableById(LookupTableDto lookupTableDto, int id)
        {
            var lookuptablefromdb = lookupTableRepo.GetLookupById(id);
            if(lookuptablefromdb !=null && lookuptablefromdb.LookupId ==id )
            {
                lookuptablefromdb.LookupName = lookupTableDto.LookupName;
            }
        }

        // ===== Update LookupTable By Name ===== //
        public void UpdateLookupTableByName(LookupTableDto lookupTableDto, string name)
        {
            var lookuptablefromdb = lookupTableRepo.GetLookupByName(name);
            if (lookuptablefromdb != null && lookuptablefromdb.LookupName== name)
            {
                lookuptablefromdb.LookupName = lookupTableDto.LookupName;
            }

        }

        #endregion

        #region All Delete Cruds for  LookupTables for Lookup Table Manager 

        // ===== Delete Lookup Table By Id ===== //
        public void DeleteLookupTableById(int id)
        {
            lookupTableRepo.DeleteLookupById(id);
        }

        // ===== Delete Lookup Table By Name ===== //
        public void DeleteLookupTableByName(string name)
        {
            lookupTableRepo.DeleteLookupByName(name);
        }
        #endregion
    }
}
