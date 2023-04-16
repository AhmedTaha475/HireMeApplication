using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface ILookupTableManager
    {
        public IEnumerable<LookupTableDto> GetAllLookupTables();
        public LookupTableDto GetLookupTableById(int id);
        public LookupTableDto GetLookupTableByName(string name);
        public void CreateNewLookupTable(LookupTableDto lookupTableDto);
        public void UpdateLookupTableById(LookupTableDto lookupTableDto, int id);

        public void  DeleteLookupTableById(int id);
        public void  DeleteLookupTableByName(string name);
    }
}
