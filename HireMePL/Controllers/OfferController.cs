using HireMeBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferManager _offerManager;

        public OfferController(IOfferManager offerManager)
        {
            this._offerManager = offerManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<OfferDto> GetAllOffers() 
        {
            var OfferLst=_offerManager.GetAllOffers();
            if(OfferLst.Count>0)
            {
                return Ok(OfferLst);
            }else { return NotFound(); }

        }



        [HttpGet]
        [Route("GetAllByFreelancerId/{id}")]
        public ActionResult<OfferDto> GetAllOffersByFreelancerId(string id)
        {
            var OfferLst = _offerManager.GetAllOffersByFreelancerId(id);
            if (OfferLst.Count > 0)
            {
                return Ok(OfferLst);
            }
            else { return NotFound(); }

        }
        [HttpGet]
        [Route("GetAllByClientId/{id}")]
        public ActionResult<OfferDto> GetAllOffersByClientId(string id)
        {
            var OfferLst = _offerManager.GetAllOffersByClientId(id);
            if (OfferLst.Count > 0)
            {
                return Ok(OfferLst);
            }
            else { return NotFound(); }
        }


        [HttpGet]
        [Route("GetOfferById/{id}")]
        public ActionResult<OfferDto> GetofferById(int id)
        {
            var Offer = _offerManager.GetOfferById(id);
            if (Offer!=null)
            {
                return Ok(Offer);
            }
            else { return NotFound(); }
        }




        [HttpPost]
        [Route("CreateOffer")]
        public ActionResult CreateOffer(CreateOfferDto createOffer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                if(_offerManager.CreateOffer(createOffer))
                    return Ok(new {Message="Offer Created Successfully"});
                return BadRequest();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        [HttpPut]
        [Route("UpdateOffer")]
        public ActionResult UpdateOffer(UpdateOfferDto updateOffer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                if (_offerManager.UpdateOffer(updateOffer))
                    return Ok(new { Message = "Offer updated Successfully" });
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }


        }

        [HttpDelete]
        [Route("DeleteOffer/{id}")]
        public ActionResult DeleteOffer(int id)
        {

            try
            {
                if (_offerManager.DeleteOffer(id))
                    return Ok(new { Message = "Offer Deleted Successfully" });
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }


        }
    }
}
