using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface IProjectPostApplicantRepo
    {
        List<ProjectPostApplicant> GetProjectPostApplicants(int projectPostId);
        List<ProjectPostApplicant> GetProjectPostApplicantById(string id);

        bool CreateProjectPostApplicant(ProjectPostApplicant projectPostApplicant);

        bool UpdateProjectPostApplicant(int id, ProjectPostApplicant projectPostApplicant);

        bool DeleteProjectPostApplicant(string id);
        int SaveChanges();
    }
}
