namespace HireMeDAL.Repos.ProjectsReview
{
    public interface IProjectsReviewRepo
    {
        public bool Add(ProjectReview review);
        public List<ProjectReview> GetAllByProjectId(int projectId);
    }
}