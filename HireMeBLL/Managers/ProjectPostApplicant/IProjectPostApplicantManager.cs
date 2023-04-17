using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IProjectPostApplicantManager
    {
        List<ProjectPostApplicantDetailsDto> GetProjectPostApplicants(int projectPostId);
        ProjectPostApplicantDetailsDto GetProjectPostApplicantById(string projectPostApplicantId);
        void CreateProjectPostApplicant(ProjectPostApplicantDetailsDto projectPostApplicant);
        void UpdateProjectPostApplicant(string projectPostApplicantId, UpdateProjectPostApplicantDto projectPostApplicant);
    }
}
