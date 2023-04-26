using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public record FreelancerDto
        (string id, string firstname, string lastname, string username
        ,string? country, string? city, string? street, byte[]? image,
        int? age, string? ssn, decimal? balance, int? paymentmethodId,
        int? planId, string email,int rank,
        string jobtitle, int bids,string description,
        decimal totalmoneyearned, byte[] CV ,decimal averagerate,string phonenumber,int? categoryId);

}
