using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface ILookupValuesRepo
    {
        
        public IEnumerable<LookupValue>  GetLookupValuesById( int id );
        public IEnumerable<LookupValue>  GetLookupValuesById( string name );

        public void CreateLookupValue(LookupValue lookvalue);
        public void UpdateLookupValueById(LookupValue lookvalue, int id);

        public void saveChanges();

    }
}
