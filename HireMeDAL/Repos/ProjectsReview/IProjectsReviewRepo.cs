namespace HireMeDAL.Repos.ProjectsReview
{
    public interface IProjectsReviewRepo
    {

        public bool Add(ProjectReview review);
        public ProjectReview GetByProjectId(int projectId);
        public List<ProjectReview> GetAllByFreeLancerId(string id);
        public List<ProjectReview> GetAllByClientId(string id);


    }
}