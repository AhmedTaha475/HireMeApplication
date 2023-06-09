﻿using HireMeBLL.Dtos;
using HireMeBLL.Dtos.Project;

namespace HireMeBLL.Managers.ProjectsManager
{
    public interface IProjectsManager
    {
       public bool CreateProject(CreateProjectDto projectDto);
        public bool DeleteProject(int id);
        public bool UpdateByProjectId(UpdateProjectByIdDto updateProjectByIdDto,int id);
        public List<ProjectDetailsReadDto> GetAllProjectsByPortfolioId(int PortFolio_Id);
        public ProjectDetailsReadDto GetById(int id);
        public List<ProjectDetailsReadDto> getAll();

        public GetProjectWithImagesDto GetProjectWithImages(int id);
    }
}