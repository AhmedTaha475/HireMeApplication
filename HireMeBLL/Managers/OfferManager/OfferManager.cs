using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class OfferManager : IOfferManager
    {
        private readonly IOfferRepo offerRepo;

        public OfferManager(IOfferRepo _offerRepo)
        {
            offerRepo = _offerRepo;
        }
        public bool CreateOffer(CreateOfferDto offer)
        {
            var Offer = new Offer()
            {
                Fullname = offer.Fullname,
                Email = offer.Email,
                ClientId = offer.ClientId,
                FreelancerId = offer.FreelancerId,
                Message = offer.Message,
                OfferDate=offer.offerDate,
                Accepted=offer.Accepted
            };
                return offerRepo.CreateOffer(Offer);
        }

        public bool DeleteOffer(int id)
        {
            return offerRepo.DeleteOffer(id);
        }

        public List<OfferDto> GetAllOffers()
        {
            return offerRepo.GetAllOffers().Select(c=>new OfferDto()
            {
                Email = c.Email,
                Message = c.Message,
                ClientId=c.ClientId,
                Fullname = c.Fullname,
                FreelancerId=c.FreelancerId,
                id=c.id,
                Accepted = c.Accepted,
                OfferDate=c.OfferDate
            }).ToList();
            
        }

        public List<OfferDto> GetAllOffersByClientId(string ClientId)
        {
            return offerRepo.GetAllOffersByClientId(ClientId).Select(c => new OfferDto()
            {
                Email = c.Email,
                Message = c.Message,
                ClientId = c.ClientId,
                Fullname = c.Fullname,
                FreelancerId = c.FreelancerId,
                id = c.id,
                OfferDate = c.OfferDate,
                Accepted=c.Accepted

            }).ToList();
        }

        public List<OfferDto> GetAllOffersByFreelancerId(string freelancerId)
        {
            return offerRepo.GetAllOffersByFreelancerId(freelancerId).Select(c => new OfferDto()
            {
                Email = c.Email,
                Message = c.Message,
                ClientId = c.ClientId,
                Fullname = c.Fullname,
                FreelancerId = c.FreelancerId,
                id = c.id,
                OfferDate = c.OfferDate,
                Accepted =c.Accepted
            }).ToList();
        }

        public OfferDto? GetOfferById(int id)
        {
            var OfferById=offerRepo.GetOfferById(id);
            if (OfferById !=null)
            {
                return new OfferDto()
                {
                    ClientId = OfferById.ClientId,
                    Email = OfferById.Email,
                    Message = OfferById.Message,
                    FreelancerId = OfferById.FreelancerId,
                    Fullname = OfferById.Fullname,
                    id = OfferById.id,
                    Accepted=OfferById.Accepted,
                    OfferDate=OfferById.OfferDate,
                };
               
            }
            return null;
        }

        public bool UpdateOffer(UpdateOfferDto offer)
        {
            var updatedOffer = offerRepo.GetOfferById(offer.id);
            if(updatedOffer != null)
            {
                updatedOffer.Fullname=offer.Fullname;
                updatedOffer.Message = offer.Message;
                updatedOffer.Email = offer.Email;
                updatedOffer.Accepted = offer.Accepted;
                updatedOffer.OfferDate = offer.OfferDate;
               return offerRepo.UpdateOffer(updatedOffer);
            }
            return false;
        }
    }
}
