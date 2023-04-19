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
        ProjectPost GetProjectPostWithApplicantsById(int id);

        bool CreateProjectPost(ProjectPost projectPost);

        bool UpdateProjectPost(int id, ProjectPost projectPost);

        bool DeleteProjectPost(int id);
        int SaveChanges();
    }
}
