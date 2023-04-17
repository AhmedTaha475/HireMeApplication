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
        ProjectPostApplicant GetProjectPostApplicantById(string id);

        void CreateProjectPostApplicant(ProjectPostApplicant projectPostApplicant);

        void UpdateProjectPostApplicant(string id, ProjectPostApplicant projectPostApplicant);

        void DeleteProjectPostApplicant(string id);
        int SaveChanges();
    }
}
