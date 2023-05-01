using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface IOfferRepo
    {


        List<Offer> GetAllOffers();

        List<Offer> GetAllOffersByFreelancerId(string freelancerId);

        List<Offer> GetAllOffersByClientId(string ClientId);

        Offer? GetOfferById(int id);

        bool CreateOffer(Offer offer);

        bool UpdateOffer(Offer offer);

        bool DeleteOffer(int id);


        int savechanges();


    }
}
