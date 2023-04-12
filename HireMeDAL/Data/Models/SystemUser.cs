using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class SystemUser:IdentityUser
    {

        /// <summary>
        /// Dont forget Nav Property
        /// </summary>
        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public byte[] Image { get; set; }

        public int Age { get; set; }

        public string SSN { get; set; }

        public decimal Balance { get; set; }


        public int PaymentMethodId { get; set; }

        public int PlanId { get; set; }

        public int CategoryId { get; set; }

        public virtual LookupValue? LookupValue { get; set; }

        public virtual HashSet<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
