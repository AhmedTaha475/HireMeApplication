using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class LookupValuesRepo : ILookupValuesRepo
    {
        public LookupValuesRepo( HireMeContext context)
        {
            Context = context;
        }

        public HireMeContext Context { get; }

        public void CreateLookupValue(LookupValue lookvalue)
        {
           Context.lookupValues.Add(lookvalue);
            saveChanges();
        }

        // ====== this function get all lookup values of specific lookup with its id ===== //
        public IEnumerable<LookupValue> GetLookupValuesByLookupId(int id)
        {
            var lookvalue = Context.lookupValues.Where(l => l.LookupId == id).ToList();
            return lookvalue;   

        }

        // ====== this function get all lookup values of specific lookup with its name ===== //
        public IEnumerable<LookupValue> GetLookupValuesByLookupName(string name)
        {
            var lookvalue = Context.lookupValues.Where(l=>l.LookupTable.LookupName.ToLower() == name.ToLower()).ToList();           
            return lookvalue;

        }

        // ====== this function update lookup values of specific lookup  ===== //
        public void UpdateLookupValueById(LookupValue lookvalue, int id , string name)
        {
            var updlookvalue = Context.lookupValues.FirstOrDefault(l => l.ValueName == name && l.LookupId == id);
            if (updlookvalue != null)
            {
                updlookvalue.ValueName = lookvalue.ValueName;
                saveChanges();

            }
        }
        // ===== this function save all operations in contet ---> to data base ====== //
        public void saveChanges()
        {
            Context.SaveChanges();
           
        }
    }
}
