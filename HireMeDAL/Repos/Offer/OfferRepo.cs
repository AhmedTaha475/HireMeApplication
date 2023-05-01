using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class OfferRepo : IOfferRepo
    {
        private readonly HireMeContext _context;

        public OfferRepo(HireMeContext Context)
        {
            _context = Context;
        }
        public bool CreateOffer(Offer offer)
        {
            _context.offers.Add(offer);
            if(savechanges()>0)
                return true;
            return false;

        }

        public bool DeleteOffer(int id)
        {
            var OfferToBeDeleted = _context.offers.Find(id);
            if(OfferToBeDeleted != null) 
            {
                _context.Remove(OfferToBeDeleted);
                if(savechanges()>0) return true;
                return false;
            }
            return false;
        }

        public List<Offer> GetAllOffers()
        {
            return _context.offers.ToList();
        }

        public List<Offer> GetAllOffersByClientId(string ClientId)
        {
            return _context.offers.Where(o=>o.ClientId == ClientId).ToList();
        }

        public List<Offer> GetAllOffersByFreelancerId(string freelancerId)
        {
            return _context.offers.Where(o=>o.FreelancerId == freelancerId).ToList();

        }

        public Offer? GetOfferById(int id)
        {
            return _context.offers.Find(id);
        }

        public int savechanges()
        {
           return _context.SaveChanges();
        }

        public bool UpdateOffer(Offer offer)
        {
            var OfferTobeUpdated = _context.offers.Find(offer.id);
            if(OfferTobeUpdated != null)
            {
                OfferTobeUpdated.Fullname = offer.Fullname;
                OfferTobeUpdated.Message= offer.Message;
                OfferTobeUpdated.Email = offer.Email;
                OfferTobeUpdated.Accepted = offer.Accepted;
                OfferTobeUpdated.OfferDate = offer.OfferDate;
                if(savechanges()>0)
                     return true;
                return false;
            }
            return false;
        }
    }
}
