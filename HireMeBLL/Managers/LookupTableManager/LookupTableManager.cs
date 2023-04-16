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
        private readonly ILookupTableRepo lookupTableRepo;
        private readonly ILookupValuesRepo lookupValuesRepo;

        public LookupTableManager( ILookupTableRepo lookupTableRepo , ILookupValuesRepo lookupValuesRepo)
        {
            this.lookupTableRepo = lookupTableRepo;
            this.lookupValuesRepo = lookupValuesRepo;
        }

        public void CreateNewLookupTable(LookupTableDto lookupTableDto)
        {
            LookupTable lookuptoDb = new LookupTable() { 
            LookupName = lookupTableDto.LookupName
            };

            lookupTableRepo.CreateNewLookup(lookuptoDb);
        }

        public void DeleteLookupTableById(int id)
        {
            lookupTableRepo.DeleteLookupById(id);
        }

        public void DeleteLookupTableByName(string name)
        {
            lookupTableRepo.DeleteLookupByName(name);
        }

        public IEnumerable<LookupTableDto> GetAllLookupTables()
        {
            var lookuptablesDb = lookupTableRepo.GetAllLookups();
            var lookupdtolist = new List<LookupTableDto>();
            var lookvaluesdtolist = new List<LookupValueDTO>();
            foreach(LookupTable lookup in lookuptablesDb)
            {
            var lookupvaluesfromdto = lookupValuesRepo.GetLookupValuesByLookupId(lookup.LookupId).Select(l=>new LookupValueDTO() { ValueId = l.ValueId , ValueName = l.ValueName , LookupId = l.LookupId });
                lookupdtolist.Add(new LookupTableDto() { LookupId = lookup.LookupId, LookupName = lookup.LookupName , lookupValuesdto = lookupvaluesfromdto.ToList() });                

            }
            return lookupdtolist;
        }

        public LookupTableDto GetLookupTableById(int id)
        {
            var lookupTablefromDb = lookupTableRepo.GetLookupById(id);
            var lookupvaluesfromdto = lookupValuesRepo.GetLookupValuesByLookupId(id).Select(l => new LookupValueDTO() { ValueId = l.ValueId, ValueName = l.ValueName, LookupId = l.LookupId });

            return new LookupTableDto() { LookupId = lookupTablefromDb.LookupId, LookupName = lookupTablefromDb.LookupName , lookupValuesdto = lookupvaluesfromdto.ToList() };
        }

        public LookupTableDto GetLookupTableByName(string name)
        {
            var lookuptablefromDb = lookupTableRepo.GetLookupByName(name);
            var lookuptablevaluesdtoname= lookupValuesRepo.GetLookupValuesByLookupName(name)
                .Select(l=>new LookupValueDTO() { LookupId=l.LookupId , ValueId=l.ValueId , ValueName = l.ValueName});

            return new LookupTableDto() { LookupId = lookuptablefromDb.LookupId, LookupName = lookuptablefromDb.LookupName, lookupValuesdto = lookuptablevaluesdtoname.ToList() };

           
        }

        public void UpdateLookupTableById(LookupTableDto lookupTableDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
