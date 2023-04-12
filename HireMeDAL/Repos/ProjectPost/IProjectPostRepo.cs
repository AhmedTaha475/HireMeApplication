using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface IProjectPostRepo
    {
        List<ProjectPost> GetALl();
        ProjectPost GetProjectPostById(int id);

        void CreateProjectPost(ProjectPost projectPost);

        void UpdateProjectPost(int id, ProjectPost projectPost);

        void DeleteProjectPost(int id);
        int SaveChanges();
    }
}
