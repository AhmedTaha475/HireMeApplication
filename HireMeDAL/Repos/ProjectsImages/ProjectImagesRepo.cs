using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos.ProjectsImages
{
    public class ProjectImagesRepo : IProjectImagesRepo
    {
        private readonly HireMeContext context;

        public ProjectImagesRepo(HireMeContext context)
        {
            this.context = context;
        }
        public bool Add(ProjectImage image)
        {

            try
            {
                context.projectImages.Add(image);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int imgId)
        {

            var toBeDeleted = context.projectImages.Find(imgId);
            if (toBeDeleted != null)
            {
                context.projectImages.Remove(toBeDeleted);
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        public List<ProjectImage> GetAllImagesByProjectId(int projectId)
        {
            return context.projectImages.Where(i=>i.ProjectId == projectId).ToList();
        }

        public ProjectImage? GetImageById(int id)
        {
            return context.projectImages.FirstOrDefault(i => i.PI_Id == id);
        }
    }
}
