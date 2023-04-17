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

        public bool Delete(int id)
        {
            var toBeDeleted = context.projectImages.Find(id);
            if (toBeDeleted != null)
            {
                context.projectImages.Remove(toBeDeleted);
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        public List<ProjectImage> GetAllByProjectId(int PId)
        {
            return context.projectImages.Where(i=>i.ProjectId == PId).ToList();
        }

        public ProjectImage GetById(int id)
        {
            return context.projectImages.FirstOrDefault(i => i.PI_Id == id);
        }

        public bool Update(ProjectImage image)
        {
           
                var projectimage = context.projectImages.Find(image.PI_Id);
                if (projectimage != null)
                {
                    projectimage.Image = image.Image;
                    context.projectImages.Update(projectimage);
                    context.SaveChanges();
                    return true;
                }
                return false;
        }
    }
}
