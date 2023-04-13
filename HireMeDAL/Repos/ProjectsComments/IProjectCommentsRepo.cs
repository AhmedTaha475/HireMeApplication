using HireMeDAL.Data.Models;

namespace HireMeDAL.Repos.ProjectsComments
{
    public interface IProjectCommentsRepo
    {   
        public List<ProjectComment> GetCommentsByProjectId(int ProjectId);
        public bool Add (ProjectComment comment);
        public bool Update (ProjectComment comment ,int id);
        public bool Delete (int id);
    }
}