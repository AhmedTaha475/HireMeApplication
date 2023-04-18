﻿using Microsoft.EntityFrameworkCore;
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
                return Enumerable.Empty<LookupTable>();
            else
                return lookuplist;
        }

        // ====== this function to get specific Lookup by id  ====== //
        public LookupTable GetLookupById(int id)
        {
            LookupTable? findlookup = Context.lookupTables.Include(l => l.LookupValues).FirstOrDefault(l => l.LookupId == id);
            if (findlookup is null)
                return new LookupTable();
            else
                return findlookup;
        }

        // ====== this function to get specific Lookup by id  ====== //
        public LookupTable GetLookupByName(string name)
        {
            LookupTable? findlookup = Context.lookupTables.Include(l => l.LookupValues).FirstOrDefault(l => l.LookupName.ToLower() == name.ToLower());
            if (findlookup is null)
                return new LookupTable();
            else
                return findlookup;
        }

        #endregion

        #region All Create Cruds for Repo Lookup Table Class
        // ====== this function to create new Lookup by id  ====== //
        public void CreateNewLookup(LookupTable lookup)
        {
            Context.lookupTables.Add(lookup);
            saveChanges();

        }

        #endregion

        #region All Update Cruds for Repo Lookup Table Class
        // ====== this function to update specific Lookup by id  ====== //
        public void UpdateLookupById(LookupTable lookup, int id)
        {
            var updlookup = Context.lookupTables.FirstOrDefault(l => l.LookupId == id);
            if (updlookup is null)
                //Console.WriteLine($" this lookup with {id} is not found");
                return;

            else
            {
                updlookup.LookupName = lookup.LookupName;
                saveChanges();
                //Console.WriteLine($" this lookup with {id} updated successfully !! ");

            }
        }

        // ====== this function to update specific Lookup by Name  ====== //
        public void UpdateLookupByName(LookupTable lookup, string name)
        {
            var updlookup = Context.lookupTables.FirstOrDefault(l => l.LookupName.ToLower() == name.ToLower());
            if (updlookup != null)

            {
                updlookup.LookupName = lookup.LookupName;
                saveChanges();

            }

        }

        #endregion

        #region All Delete Cruds for Repo Lookup Table Class

        // ====== this function to delete specific Lookup by id  ====== //
        public void DeleteLookupById(int id)
        {
            LookupTable? dellookup = Context.lookupTables.FirstOrDefault(l => l.LookupId == id);
            if (dellookup != null)

            {
                Context.lookupTables.Remove(dellookup);
                saveChanges();
            }

        }

        // ====== this function to delete specific Lookup by name  ====== //
        public void DeleteLookupByName(string name)
        {

            LookupTable? dellookup = Context.lookupTables.FirstOrDefault(l => l.LookupName.ToLower() == name.ToLower());
            if (dellookup != null)

            {
                Context.lookupTables.Remove(dellookup);
                saveChanges();

            }
        }

        // ===== this function save all operations in contet ---> to data base ====== //
        public void saveChanges()
        {
            Context.SaveChanges();
        }


        #endregion

    }
}
