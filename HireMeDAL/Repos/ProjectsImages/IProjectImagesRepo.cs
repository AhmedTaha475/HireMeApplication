namespace HireMeDAL.Repos.ProjectsImages
{
    public interface IProjectImagesRepo
    {
        public List<ProjectImage> GetAllImagesByProjectId(int projectId);
        public ProjectImage? GetImageById(int id);
        public bool Add(ProjectImage image);
        public bool Delete(int imgId);
    }
}