using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class LookupTableRepo : ILookupTableRepo
    {
        #region Constructor && All Injection Requires for Repo Lookup Table Class 
        private readonly HireMeContext Context;
        public LookupTableRepo( HireMeContext context)
        {
            Context = context;
        }

       
        #endregion

        #region All Get Cruds for Repo Lookup Table Class
        // ====== this function to get All Lookups ====== //
        public IEnumerable<LookupTable> GetAllLookups()
        {
            var lookuplist = Context.lookupTables.Include(l => l.LookupValues).ToList();
            if (lookuplist is null)
                return null;
            else
                return lookuplist;
        }

        // ====== this function to get specific Lookup by id  ====== //
        public LookupTable GetLookupById(int id)
        {
            LookupTable? findlookup = Context.lookupTables.Include(l => l.LookupValues).FirstOrDefault(l => l.LookupId == id);
            if (findlookup is null)
                return null;
            else
                return findlookup;
        }

        // ====== this function to get specific Lookup by id  ====== //
        public LookupTable GetLookupByName(string name)
        {
            LookupTable? findlookup = Context.lookupTables.Include(l => l.LookupValues).FirstOrDefault(l => l.LookupName.ToLower() == name.ToLower());
            if (findlookup is null)
                return null;
            else
                return findlookup;
        }

        #endregion

        #region All Create Cruds for Repo Lookup Table Class
        // ====== this function to create new Lookup by id  ====== //
        public bool CreateNewLookup(LookupTable lookup)
        {
            try
            {
                Context.lookupTables.Add(lookup);
                saveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
         

        }

        #endregion

        #region All Update Cruds for Repo Lookup Table Class
        // ====== this function to update specific Lookup by id  ====== //
        public bool UpdateLookupById(string name, int id)
        {
            var updlookup = Context.lookupTables.FirstOrDefault(l => l.LookupId == id);
            if (updlookup is null)
                //Console.WriteLine($" this lookup with {id} is not found");
                return false;

            else
            {
                updlookup.LookupName = name;
                saveChanges();
                //Console.WriteLine($" this lookup with {id} updated successfully !! ");
                return true;
            }
        }

        // ====== this function to update specific Lookup by Name  ====== //
        public bool UpdateLookupByName(LookupTable lookup, string name)
        {
            var updlookup = Context.lookupTables.FirstOrDefault(l => l.LookupName.ToLower() == name.ToLower());
            if (updlookup != null)
            {
                updlookup.LookupName = lookup.LookupName;
                saveChanges();
                return true;
            }return false;

        }

        #endregion

        #region All Delete Cruds for Repo Lookup Table Class

        // ====== this function to delete specific Lookup by id  ====== //
        public bool DeleteLookupById(int id)
        {
            LookupTable? dellookup = Context.lookupTables.FirstOrDefault(l => l.LookupId == id);
            if (dellookup != null)
            {
                Context.lookupTables.Remove(dellookup);
                saveChanges();
                return true;
            }
            return false;

        }

        // ====== this function to delete specific Lookup by name  ====== //
        public bool DeleteLookupByName(string name)
        {

            LookupTable? dellookup = Context.lookupTables.FirstOrDefault(l => l.LookupName.ToLower() == name.ToLower());
            if (dellookup != null)
            {

                Context.lookupTables.Remove(dellookup);
                saveChanges();
                return true;
            }
            else { return false; }
        }

        // ===== this function save all operations in contet ---> to data base ====== //
        public void saveChanges()
        {
            Context.SaveChanges();
        }


        #endregion

    }
}
