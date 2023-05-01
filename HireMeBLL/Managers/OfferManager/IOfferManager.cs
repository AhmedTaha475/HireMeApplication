using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IOfferManager
    {
        List<OfferDto> GetAllOffers();

        List<OfferDto> GetAllOffersByFreelancerId(string freelancerId);

        List<OfferDto> GetAllOffersByClientId(string ClientId);

        OfferDto? GetOfferById(int id);

        bool CreateOffer(CreateOfferDto offer);

        bool UpdateOffer(UpdateOfferDto offer);

        bool DeleteOffer(int id);
    }
}
