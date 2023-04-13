using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface IProjectPostApplicantRepo
    {
        List<ProjectPostApplicant> GetALl();
        ProjectPostApplicant GetProjectPostApplicantById(int id);

        void CreateProjectPostApplicant(ProjectPostApplicant projectPostApplicant);

        void UpdateProjectPostApplicant(int id, ProjectPostApplicant projectPostApplicant);

        void DeleteProjectPostApplicant(int id);
        int SaveChanges();
    }
}
