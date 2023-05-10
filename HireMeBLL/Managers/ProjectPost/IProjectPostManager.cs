using HireMeBLL.Dtos.ProjectPost;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IProjectPostManager
    {
        bool CreateProjectPost(CreateProjectPostDto createProjectPostDto, string clientId);
        bool UpdateProjectPost(int projectPostId, UpdateProjectPostDto updateProjectPostDto, string clientId);
        bool DeleteProjectPost(int projectPostId);
        ProjectPostWithApplicantsDetailsDto GetProjectPostWithApplicantsById(int projectId);

        List<ProjectPostDto> GetAll();
        ProjectPostDto GetProjectPostById(int id);

        List<ProjectPostDto> GetProjectPostsByClientId(string clientId);

    }
}
