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

            if (lookupTableRepo.CreateNewLookup(lookuptoDb)) 
            { 
                return true;
            }
            return false;
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
               if( lookupTableRepo.UpdateLookupById(name, id))
                { return true; }
               return false;
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
                if(lookupTableRepo.UpdateLookupByName(lookuptablefromdb, name))
                { return true; }
                return false;
            }
            return false;

        }

        #endregion

        #region All Delete Cruds for  LookupTables for Lookup Table Manager 

        // ===== Delete Lookup Table By Id ===== //
        public bool DeleteLookupTableById(int id)
        {
            if(lookupTableRepo.DeleteLookupById(id))
            { return true; }
            return false;
        }

        // ===== Delete Lookup Table By Name ===== //
        public bool DeleteLookupTableByName(string name)
        {
            if(lookupTableRepo.DeleteLookupByName(name))
            {
                return true;
            }return false;
        }
        #endregion

    }
}
