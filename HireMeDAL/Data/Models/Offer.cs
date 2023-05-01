using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public  class Offer
    {
        [Key]
        public int id { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
        public DateTime? OfferDate { get; set; }
        public bool? Accepted { get; set; }
        public string ClientId { get; set; }
        public string FreelancerId { get; set; }
        [ForeignKey("FreelancerId")]
        public virtual Freelancer? Freelancer { get; set; }




    }
}
