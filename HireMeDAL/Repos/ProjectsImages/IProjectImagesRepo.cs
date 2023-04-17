namespace HireMeDAL.Repos.ProjectsImages
{
    public interface IProjectImagesRepo
    {
        public List<ProjectImage> GetAllByProjectId(int PId);
        public ProjectImage GetById(int id);
        public bool Add (ProjectImage image);
        public bool Delete(int id);
    }
}