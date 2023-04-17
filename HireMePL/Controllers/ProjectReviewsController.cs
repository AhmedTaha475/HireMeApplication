using HireMeBLL;
using HireMeBLL.Dtos.ProjectReview;
using HireMeBLL.Managers.ProjectComment;
using HireMeDAL;
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
        public ActionResult<List<UserPojectReviewReadDto>> GetAllByFreeLancerId(string FL_id)
        {
           return projectReviewManager.GetReviewsByFreeLancerId(FL_id);
        }

        [HttpGet]
        [Route("ClientReviews/{id}")]
        public ActionResult<List<UserPojectReviewReadDto>> GetAllByClientrId(string Client_id)
        {
            return projectReviewManager.GetReviewsByClientId(Client_id);
        }
        [HttpGet]
        [Route("ProjectReview/{id}")]
        public ActionResult<PojectReviewReadDto> GetReviewByProjectId(int P_Id)
        {
            return projectReviewManager.GetReviewByProjectId(P_Id);
        }
        [HttpPost]
        [Route("AddClientReview")]
        public ActionResult AddClientReview(CreateClientProjectReviewDto createClientReviewdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!projectReviewManager.AddClientReview(createClientReviewdto))
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        [Route("AddFreelancerReview")]
        public ActionResult AddFreeLancerReview(CreateFreeLancerProjectReviewDto createFreeLancerReviewdto,int PR_Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!projectReviewManager.AddFreeLancerReview(createFreeLancerReviewdto,PR_Id))
                return BadRequest();
            return Ok();
        }
    }
}
