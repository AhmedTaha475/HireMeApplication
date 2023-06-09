﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class LookupValuesRepo : ILookupValuesRepo
    {
        #region Constructor && All Injection Requires for Repo Lookup Values Class 
        private readonly HireMeContext Context;
        public LookupValuesRepo( HireMeContext context)
        {
            Context = context;
        }

        
        #endregion

        #region All Get Cruds for Repo Lookup Values Class

        // ====== this function get all lookup values of specific lookup with its id ===== //
        public IEnumerable<LookupValue> GetLookupValuesByLookupId(int id)
        {
            var lookvalue = Context.lookupValues.Where(l => l.LookupId == id).ToList();
            if(lookvalue.Count!=0)
            {
            return lookvalue;

            }return null;

        }

        // ====== this function get all lookup values of specific lookup with its name ===== //
        public IEnumerable<LookupValue> GetLookupValuesByLookupName(string name)
        {
            var lookvalue = Context.lookupValues.Where(l => l.LookupTable.LookupName.ToLower() == name.ToLower()).ToList();
            if( lookvalue.Count!=0 )
            {
            return lookvalue;

            }return null;

        }

        // ==== thsis function to get lookup value by its id ===== // 
        public LookupValue GetLookupValueById(int id)
        {
            var lookupValue = Context.lookupValues.FirstOrDefault(l => l.ValueId == id);
            return lookupValue; 
        }

        #endregion

        #region All Create Cruds for Repo Lookup Values Class

        // ====== this function create new lookup value ===== //
        public bool CreateLookupValue(LookupValue lookvalue)
        {
            try
            {
                Context.lookupValues.Add(lookvalue);
                saveChanges();
                return true;
            }
            catch   (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region All Update Cruds for Repo Lookup Values Class

        // ====== this function update lookup values of specific lookup  ===== //
        public bool UpdateLookupValueById(LookupValue lookvalue, int id)
        {
            var updlookvalue = Context.lookupValues.FirstOrDefault(l => l.ValueId == id);
            if (updlookvalue != null)
            {
                updlookvalue.ValueName = lookvalue.ValueName;
                saveChanges();
                return true;
            }return false;
        }

        // ===== this function save all operations in contet ---> to data base ====== //
        public void saveChanges()
        {
            Context.SaveChanges();

        }

        #endregion

        #region All Delete Cruds for Repo Lookup Values Class
        // ==== this function to delete lookup value by Id ==== //
        public bool DeleteLookupValueById(int id)
        {
            LookupValue? lookupdel = Context.lookupValues.Find(id);
            if (lookupdel != null)
            {
                Context.lookupValues.Remove(lookupdel);
                Context.SaveChanges();
                return true;
            }return false;
        }

        public List<LookupValue> GetAllLookupValues()
        {
            var valuesList=Context.lookupValues.ToList();

            if (valuesList.Count == 0)
                return null;
            return valuesList;            
        }



        #endregion

    }
}
