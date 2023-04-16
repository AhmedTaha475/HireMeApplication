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
        // in need to put validator here         
        public DateTime DateOfTransaction { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]        
        public decimal Amount { get; set; }

        [StringLength(150, MinimumLength = 2,ErrorMessage =" the max number of chars are 150 char ! Dont Exceed them .. ")]
        public string Description { get; set; } = string.Empty;

        public TransactionReadDto( DateTime dateTime , decimal amount , string description)
        
        { 
            DateOfTransaction = dateTime;
            Amount = amount;
            Description = description;

        }
        
            
        
    }
}
