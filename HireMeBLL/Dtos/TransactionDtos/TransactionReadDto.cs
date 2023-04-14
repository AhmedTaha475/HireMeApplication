using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HireMeBLL
{
    public class TransactionReadDto
    {
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateOfTransaction { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]        
        public decimal Amount { get; set; }

        [StringLength(150, MinimumLength = 2)]
        public string Description { get; set; } = string.Empty;

        public TransactionReadDto( DateTime dateTime , decimal amount , string description)
        
        { 
            DateOfTransaction = dateTime;
            Amount = amount;
            Description = description;

        }
        
            
        
    }
}
