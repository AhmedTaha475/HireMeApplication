using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        //[Column(TypeName ="datetime")]
        public DateTime DateOfTransaction { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public string SystemUserId { get; set; }

        [ForeignKey("SystemUserId")]
        public virtual SystemUser? SystemUser { get; set; }
    }
}
