using HireMeBLL.Dtos.ProjectReview;
using Microsoft.AspNetCore.Mvc;

namespace HireMeBLL
{
    public interface IProjectReviewManager
    {
        public bool AddClientReview(CreateClientProjectReviewDto createClientReviewdto);
        public bool AddFreeLancerReview(CreateFreeLancerProjectReviewDto createFreeLancerReviewdto, int PR_Id);
        public PojectReviewReadDto GetReviewByProjectId(int p_Id);
        public List<UserPojectReviewReadDto> GetReviewsByClientId(string client_id);
        public List<UserPojectReviewReadDto> GetReviewsByFreeLancerId(string fL_id);
    }
}