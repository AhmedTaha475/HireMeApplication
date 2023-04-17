using HireMeDAL.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HireMeDAL { 
    public interface IProjectCommentsRepo
    {
        public List<ProjectComment> GetAllByProjectId(int projectId);
        public bool Add(ProjectComment comment);
        public bool Update(ProjectComment comment,int id);
        public bool Delete(int id);
    }
}