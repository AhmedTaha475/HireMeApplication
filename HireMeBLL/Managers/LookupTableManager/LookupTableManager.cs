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
        public LookupTableManager( ILookupTableRepo lookupTableRepo )
        {
            this.lookupTableRepo = lookupTableRepo;

        }
        #endregion

        #region All Get Cruds for  LookupTables for Lookup Table Manager 

        // ======  Get ALL Lookup Tables  ===== //  
        public IEnumerable<LookupTableDto> GetAllLookupTables()
        {
            var lookuptablesDb = lookupTableRepo.GetAllLookups();
            if( lookuptablesDb != null ) 
            {
            return lookuptablesDb.Select(c => new LookupTableDto() { LookupId = c.LookupId, LookupName = c.LookupName }).ToList();

            }
            else
            {
                return null;
            }
        }

        // ======  Get Lookup Table By Id  ===== // 
        public LookupTableDto GetLookupTableById(int id)
        {
            var lookupTablefromDb = lookupTableRepo.GetLookupById(id);
            if (lookupTablefromDb != null)
            {
                return new LookupTableDto() { LookupId = lookupTablefromDb.LookupId, LookupName = lookupTablefromDb.LookupName };

            }
            else
                return null;
        }

        #endregion

        #region All Create Cruds for  LookupTables for Lookup Table Manager 
        public bool CreateNewLookupTable(string name)
        {
            LookupTable lookuptoDb = new LookupTable() { 
            LookupName = name
            };

            return lookupTableRepo.CreateNewLookup(lookuptoDb);
        }
        #endregion
       
        #region All  Update Cruds for  LookupTables for Lookup Table Manager 


        // ===== Update LookupTable By Id ===== //
        public bool UpdateLookupTableById(string name, int id)
        {
            var lookuptablefromdb = lookupTableRepo.GetLookupById(id);
            if(lookuptablefromdb !=null && lookuptablefromdb.LookupId ==id )
            {
                lookuptablefromdb.LookupName = name;
                return lookupTableRepo.UpdateLookupById(name, id);
            }
            return false;
        }

        // ===== Update LookupTable By Name ===== //
        public bool UpdateLookupTableByName(LookupTableDto lookupTableDto, string name)
        {
            var lookuptablefromdb = lookupTableRepo.GetLookupByName(name);
            if (lookuptablefromdb != null && lookuptablefromdb.LookupName== name)
            {
                lookuptablefromdb.LookupName = lookupTableDto.LookupName;
                return lookupTableRepo.UpdateLookupByName(lookuptablefromdb, name);
            }
            return false;

        }

        #endregion

        #region All Delete Cruds for  LookupTables for Lookup Table Manager 

        // ===== Delete Lookup Table By Id ===== //
        public bool DeleteLookupTableById(int id)
        {
            return lookupTableRepo.DeleteLookupById(id);
        }

        // ===== Delete Lookup Table By Name ===== //
        public bool DeleteLookupTableByName(string name)
        {
             return lookupTableRepo.DeleteLookupByName(name);
        }
        #endregion

    }
}
