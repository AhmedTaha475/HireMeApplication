using HireMeBLL.Dtos.ProectImage;
using HireMeDAL.Repos.ProjectsImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class ProjectImageManager : IProjectImageManager
    {
        private readonly IProjectImagesRepo _projectImagesRepo;

        public ProjectImageManager(IProjectImagesRepo projectImagesRepo)
        {
            this._projectImagesRepo = projectImagesRepo;
        }
        public bool Add(CreateProjectImageDto image)
        {
            var result = _projectImagesRepo.Add(
                new HireMeDAL.ProjectImage() { ProjectId = image.ProjectId, Image = Helper.ConvertFromFileToByteArray(image.Image) });
            return result;
        }

        public bool Delete(int id)
        {
            var result= _projectImagesRepo.Delete(id);
            return result;
        }

        public List<ProjectImageDto> GetAllByProjectId(int PId)
        {
            var projectimage=_projectImagesRepo.GetAllByProjectId(PId).Select(c=>new ProjectImageDto(c.PI_Id,c.ProjectId,c.Image)).ToList();
            return projectimage;
        }

        public ProjectImageDto GetById(int id)
        {
            var result= _projectImagesRepo.GetById(id);
            return new ProjectImageDto(result.PI_Id, result.ProjectId, result.Image);
        }

        public bool Update(UpdateProjectImageDto image)
        {
            var result = _projectImagesRepo
                .Update(new HireMeDAL.ProjectImage() { PI_Id = image.PI_id,
                    Image = Helper.ConvertFromFileToByteArray(image.image) });

            return result;
        }
    }
}
