using HireMeBLL.Dtos;
using HireMeBLL.Dtos.Project;

namespace HireMeBLL.Managers.ProjectsManager
{
    public interface IProjectsManager
    {
       public bool CreateProject(CreateProjectDto projectDto);
    }
}