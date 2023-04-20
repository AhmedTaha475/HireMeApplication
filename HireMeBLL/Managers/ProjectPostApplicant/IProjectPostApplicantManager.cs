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
        List<ProjectPostApplicantDetailsDto> GetProjectPostApplicantById(string projectPostApplicantId);
        bool CreateProjectPostApplicant(ProjectPostApplicantDetailsDto projectPostApplicant);
        bool UpdateProjectPostApplicant(int projectPostId, UpdateProjectPostApplicantDto projectPostApplicant);
    }
}
