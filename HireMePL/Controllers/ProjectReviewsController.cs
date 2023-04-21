using HireMeBLL;
using HireMeBLL.Dtos.ProjectReview;
using HireMeBLL.Managers.ProjectComment;
using HireMeDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectReviewsController : ControllerBase
    {
        private readonly IProjectReviewManager projectReviewManager;
        private readonly UserManager<IdentityUser> userManager;

        public ProjectReviewsController(IProjectReviewManager projectReviewManager, UserManager<IdentityUser> userManager)
        {
            this.projectReviewManager = projectReviewManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("FreelancerReviews/{id}")]
        [Authorize(policy:"Freelancer")]
        public ActionResult<List<UserPojectReviewReadDto>> GetAllByFreeLancerId(string id)
        {
            var ReviewList= projectReviewManager.GetReviewsByFreeLancerId(id);
            if (ReviewList!=null)
            {
                return Ok(ReviewList);

            }return NotFound(new { Message = "Reviews not found" });
        }

        [HttpGet]
        [Route("ClientReviews/{id}")]
        [Authorize(policy:"Client")]
        public ActionResult<List<UserPojectReviewReadDto>> GetAllByClientrId(string id)
        {
              var ReviewList =projectReviewManager.GetReviewsByClientId(id);
            if (ReviewList!=null)
            {
                return Ok(ReviewList);

            }return NotFound(new { message = "Reviews not found" });
        }
        [HttpGet]
        [Route("ProjectReview/{Id}")]
        [Authorize]
        public ActionResult<PojectReviewReadDto> GetReviewByProjectId(int Id)
        {
              var Review=  projectReviewManager.GetReviewByProjectId(Id);
            if (Review != null)
                return Ok(Review);
            return NotFound(new { message = "Review not found" });
        }
        [HttpPost]
        [Route("AddClientReview")]
        [Authorize(policy:"Client")]
        public ActionResult AddClientReview(CreateClientProjectReviewDto createClientReviewdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!projectReviewManager.AddClientReview(createClientReviewdto))
                    return BadRequest(new {message="Somethign went wrong ....."});
                return Ok(new {message="Client review added"});
            }catch  (Exception ex) { return BadRequest(ex.Message); };
            
        }

        [HttpPut]
        [Route("AddFreelancerReview/{PR_Id}")]
        [Authorize(policy:"Freelancer")]
        public ActionResult AddFreeLancerReview(CreateFreeLancerProjectReviewDto createFreeLancerReviewdto,int PR_Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!projectReviewManager.AddFreeLancerReview(createFreeLancerReviewdto, PR_Id))
                    return BadRequest(new { message = "Somethign went wrong ....." });
                return Ok(new { message = "Freelancer review added" });
            }catch (Exception ex) { return BadRequest(ex.Message); }
            
        }
    }
}
