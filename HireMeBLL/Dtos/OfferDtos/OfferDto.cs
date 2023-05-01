using HireMeDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record OfferDto
    {
      
        public int id { get; init; }

        public string Fullname { get; init; }

        public string Email { get; init; }

        public string Message { get; init; }

        public string ClientId { get; init; }

        public string FreelancerId { get; init; }

        public bool? Accepted { get; init; }

        public DateTime? OfferDate { get; init; }


    }
}
