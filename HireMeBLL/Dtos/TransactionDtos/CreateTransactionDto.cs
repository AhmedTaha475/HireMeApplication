using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Dtos.TransactionDtos
{
    public record CreateTransactionDto
    {
        [Required]
        //[DateInPast]
        public DateTime DateOfTransaction { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [StringLength(150, MinimumLength = 2, ErrorMessage = " the max number of chars are 150 char ! Dont Exceed them .. ")]
        public string Description { get; set; } = string.Empty;
    }
}
