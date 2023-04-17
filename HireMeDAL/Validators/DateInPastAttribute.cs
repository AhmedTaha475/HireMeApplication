using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class DateInPastAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
           DateTime? date = value as DateTime?;
            if (date != null)
            {
                return false; 
            }
            if(date < DateTime.Now)
            {
                return true;
            }

            return false; 
        }
    }
}
