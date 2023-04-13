using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IProjectPostManager
    {
        void CreateProjectPost(CreateProjectPostDto createProjectPostDto, string clientId);
        void UpdateProjectPost(int projectPostId, UpdateProjectPostDto updateProjectPostDto, string clientId);
        void DeleteProjectPost(int projectPostId);
        ProjectPostApplicantDetailsDto GetProjectPostWithApplicantsById(int projectId);
    }
}
