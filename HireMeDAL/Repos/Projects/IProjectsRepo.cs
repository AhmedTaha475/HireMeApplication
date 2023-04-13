using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos.Projects
{
   public interface IProjectsRepo
    {
        public List<Project>? GetAll();
        public Project? GetById(int id);
        public Project? GetByName(string Name);
        public bool Add(Project project);
        public bool Update(Project project,int id);
        public bool Delete(int id);
    }
}
