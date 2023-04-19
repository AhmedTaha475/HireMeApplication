using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeDAL;

namespace HireMeDAL
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [DateInPast]
        public DateTime DateOfTransaction { get; set; }

        [Required]
        [Column(TypeName = "money")]
        
        public decimal Amount { get; set; }

        [StringLength(150,MinimumLength =2)]
        public string Description { get; set; } = string.Empty;

        public string SystemUserId { get; set; }

        [ForeignKey("SystemUserId")]
        public virtual SystemUser? SystemUser { get; set; }

        public Transaction( DateTime datetime , decimal amount , string descreption,string userId)
        {
            DateOfTransaction = datetime;
            Amount = amount;
            Description = descreption;
            SystemUserId=userId;
        }

        public Transaction()
        {
            
        }
    }
}
