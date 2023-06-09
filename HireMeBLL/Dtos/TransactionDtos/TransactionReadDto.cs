﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeDAL;


namespace HireMeBLL
{
    public record TransactionReadDto
    {

        public int Id { get; set; }
        public DateTime DateOfTransaction { get; set; }

          
        public decimal Amount { get; set; }

        
        public string Description { get; set; } = string.Empty;
        
    }
}
