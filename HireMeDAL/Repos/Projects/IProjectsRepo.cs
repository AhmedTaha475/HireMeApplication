using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HireMeDAL.Repos.Projects
{
    public interface IProjectsRepo
    {
        public bool Add(Project project);
        public bool Delete(int id);
        public List<Project>? GetAll();
        public Project? GetById(int id);
        public Project? GetByName(string Name);
        public bool Update(Project project, int id);

        public Project? GetProjectWithImages(int id);
        public List<Project>? GetAllByPortfolioId(int Portfolio_Id);
    }
}
